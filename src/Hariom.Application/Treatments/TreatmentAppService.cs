using Hariom.Localization;
using Hariom.Mantras;
using Hariom.Medicines;
using Hariom.Permissions;
using Hariom.TreatmentDiseaseMaps;
using Hariom.TreatmentMantraMaps;
using Hariom.TreatmentMedicineMaps;
using Hariom.TreatmentYogTherapyMaps;
using Hariom.YogTherapies;
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

        protected ITreatmentRepository TreatmentRepository { get; }
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
            TreatmentRepository = treatmentRepository;
        }

        public override async Task<TreatmentDto> CreateAsync(CreateUpdateTreatmentDto input)
        {
            
            var treatmentDto =  await base.CreateAsync(input);

            var diseaseMaps = input.SelectedDiseases
                .Select(i => TreatmentDiseaseMapManager.Create(treatmentDto.Id, i)).ToList();

            await TreatmentDiseaseMapRepository.InsertManyAsync(diseaseMaps);

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

        public override async Task<TreatmentDto> UpdateAsync(Guid id, CreateUpdateTreatmentDto input)
        {

            await TreatmentDiseaseMapRepository.DeleteDirectAsync(i => i.TreatmentId == id);
            await TreatmentMedicineMapRepository.DeleteDirectAsync(i => i.TreatmentId == id);
            await TreatmentMantraMapRepository.DeleteDirectAsync(i => i.TreatmentId == id);
            await TreatmentYogTherapyMapRepository.DeleteDirectAsync(i => i.TreatmentId == id);

            var treatmentDto = await base.UpdateAsync(id, input);

            var diseaseMaps = input.SelectedDiseases
                .Select(i => TreatmentDiseaseMapManager.Create(treatmentDto.Id, i)).ToList();

            await TreatmentDiseaseMapRepository.InsertManyAsync(diseaseMaps);

            await TreatmentMedicineMapRepository.InsertManyAsync(input.SelectedMedicines
                .Select(i => TreatmentMedicineMapManager.Create(treatmentDto.Id, i)));

            if (input.SelectedMantras?.Any() == true)
            {
                await TreatmentMantraMapRepository.InsertManyAsync(input.SelectedMantras
                .Select(i => TreatmentMantraMapManager.Create(treatmentDto.Id, i)));
            }

            if (input.SelectedYogtheropies?.Any() == true)
            {
                await TreatmentYogTherapyMapRepository.InsertManyAsync(input.SelectedYogtheropies
                .Select(i => TreatmentYogTherapyMapManager.Create(treatmentDto.Id, i)));
            }


            return treatmentDto;
        }

        public async Task<TreatmentNavigationModelDto> GetByIdAsync(Guid id)
        {
            var datas = await TreatmentRepository.GetByIdAsync(id);
            var treatmentNavigationModelDto = ObjectMapper.Map<TreatmentNavigationModel, TreatmentNavigationModelDto>(datas[0]);

            treatmentNavigationModelDto.Diseases = datas
                .Where(i => i.DiseaseId != null)
                .Select(i => new Diseases.DiseaseDto
                {
                    Id = (Guid)i.DiseaseId!,
                    Name = i.DiseaseName!
                }).DistinctBy(i => i.Id)
                .ToList();

            treatmentNavigationModelDto.Medicines = datas
                .Where(i => i.MedicineId != null)
                .Select(i => new MedicineDto
                {
                    Id = (Guid)i.MedicineId!,
                    Name = i.MedicineName!
                }).DistinctBy(i => i.Id)
                .ToList();

            treatmentNavigationModelDto.Mantras = datas
                .Where(i => i.MantrasId != null)
                .Select(i => new MantraDto
                {
                    Id = (Guid)i.MantrasId!,
                    Name = i.MantrasName!
                }).DistinctBy(i => i.Id)
                .ToList();

            treatmentNavigationModelDto.YogTherapies = datas
                .Where(i => i.YogTherapyId != null)
                .Select(i => new YogTherapyDto
                {
                    Id = (Guid)i.YogTherapyId!,
                    YogopcharTherapy = i.YogopcharTherapy!
                }).DistinctBy(i => i.Id)
                .ToList();

            return treatmentNavigationModelDto;
        }
    }
}
