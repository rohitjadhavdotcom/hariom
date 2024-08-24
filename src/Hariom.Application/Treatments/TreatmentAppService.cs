using Hariom.Localization;
using Hariom.Permissions;
using Hariom.TreatmentDiseaseMaps;
using Hariom.TreatmentMantraMaps;
using Hariom.TreatmentMedicineMaps;
using Hariom.TreatmentYogTherapyMaps;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Hariom.Treatments
{
    public class TreatmentAppService:
        CrudAppService<
        Treatment, //The Book entity
        TreatmentDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateTreatmentDto>, //Used to create/update a book
        ITreatmentAppService //implement the IBookAppService
    {
        protected IStringLocalizer<HariomResource> StringLocalizer { get; }

        protected ITreatmentDiseaseMapRepository TreatmentDiseaseMapRepository { get; }
        protected TreatmentDiseaseMapManager TreatmentDiseaseMapManager { get; }
        protected ITreatmentMedicineMapRepository TreatmentMedicineMapRepository { get; }
        protected TreatmentMedicineMapManager TreatmentMedicineMapManager { get; }
        protected ITreatmentMantraMapRepository TreatmentMantraMapRepository { get; }
        protected TreatmentMantraMapManager TreatmentMantraMapManager { get; }
        protected ITreatmentYogTherapyMapRepository TreatmentYogTherapyMapRepository { get; }
        protected TreatmentYogTherapyMapManager TreatmentYogTherapyMapManager { get; }

        public TreatmentAppService(IRepository<Treatment, Guid> repository,
            ITreatmentRepository treatmentRepository,
            TreatmentManager treatmentManager,
            IStringLocalizer<HariomResource> stringLocalizer,
            ITreatmentDiseaseMapRepository treatmentDiseaseMapRepository,
            ITreatmentMedicineMapRepository treatmentMedicineMapRepository,
            ITreatmentMantraMapRepository treatmentMantraMapRepository,
            ITreatmentYogTherapyMapRepository treatmentYogTherapyMapRepository,
            TreatmentDiseaseMapManager treatmentDiseaseMapManager,
            TreatmentMedicineMapManager treatmentMedicineMapManager,
            TreatmentMantraMapManager treatmentMantraMapManager,
            TreatmentYogTherapyMapManager treatmentYogTherapyMapManager
            )
        : base(repository)
        {
            GetPolicyName = HariomPermissions.Treatments.Default;
            GetListPolicyName = HariomPermissions.Treatments.Default;
            CreatePolicyName = HariomPermissions.Treatments.Create;
            UpdatePolicyName = HariomPermissions.Treatments.Edit;
            DeletePolicyName = HariomPermissions.Treatments.Delete;
            StringLocalizer = stringLocalizer;
            TreatmentDiseaseMapRepository = treatmentDiseaseMapRepository;
            TreatmentMedicineMapRepository = treatmentMedicineMapRepository;
            TreatmentMantraMapRepository = treatmentMantraMapRepository;
            TreatmentYogTherapyMapRepository = treatmentYogTherapyMapRepository;

            TreatmentDiseaseMapManager = treatmentDiseaseMapManager;
            TreatmentMedicineMapManager = treatmentMedicineMapManager;
            TreatmentMantraMapManager = treatmentMantraMapManager;
            TreatmentYogTherapyMapManager = treatmentYogTherapyMapManager;
        }

        public override async Task<TreatmentDto> CreateAsync(CreateUpdateTreatmentDto input)
        {
            
            var treatmentDto =  await base.CreateAsync(input);

            await TreatmentDiseaseMapRepository.InsertManyAsync(input.SelectedDiseases
                .Select(i => TreatmentDiseaseMapManager.Create(treatmentDto.Id, i)));

            await TreatmentMedicineMapRepository.InsertManyAsync(input.SelectedMedicines
                .Select(i => TreatmentMedicineMapManager.Create(treatmentDto.Id, i)));

            if (input.SelectedMantras?.Any() == true) {
                await TreatmentMantraMapRepository.InsertManyAsync(input.SelectedMantras
                .Select(i => TreatmentMantraMapManager.Create(treatmentDto.Id, i)));
            }
             
            if (input.SelectedYogtheropies?.Any() == true) {
                await TreatmentYogTherapyMapRepository.InsertManyAsync(input.SelectedYogtheropies
                .Select(i => TreatmentYogTherapyMapManager.Create(treatmentDto.Id, i)));
            }
            

            return treatmentDto;
        }

    }
}
