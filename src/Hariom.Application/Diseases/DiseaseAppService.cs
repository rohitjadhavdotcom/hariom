using Hariom.Localization;
using Hariom.Permissions;
using Hariom.Treatments;
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

namespace Hariom.Diseases
{
    public class DiseaseAppService:
        CrudAppService<
        Disease, //The Book entity
        DiseaseDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateDiseaseDto>, //Used to create/update a book
        IDiseaseAppService //implement the IBookAppService
    {

        private readonly IDiseaseRepository _diseaseRepository;
        private readonly DiseaseManager _diseaseManager;
        protected IStringLocalizer<HariomResource> StringLocalizer { get;  }

        public DiseaseAppService(IRepository<Disease, Guid> repository, IDiseaseRepository diseaseRepository, DiseaseManager diseaseManager, IStringLocalizer<HariomResource> stringLocalizer)
        : base(repository)
        {
            GetPolicyName = HariomPermissions.Diseases.Default;
            GetListPolicyName = HariomPermissions.Diseases.Default;
            CreatePolicyName = HariomPermissions.Diseases.Create;
            UpdatePolicyName = HariomPermissions.Diseases.Edit;
            DeletePolicyName = HariomPermissions.Diseases.Delete;
            _diseaseManager = diseaseManager;
            _diseaseRepository = diseaseRepository;
            StringLocalizer = stringLocalizer;
        }

        [Authorize(HariomPermissions.Diseases.Create)]
        public override async Task<DiseaseDto> CreateAsync(CreateUpdateDiseaseDto input)
        {
            try
            {
                var disease = await _diseaseManager.CreateAsync(
                input.Name);

                await _diseaseRepository.InsertAsync(disease);

                return ObjectMapper.Map<Disease, DiseaseDto>(disease);
            }
            catch (DiseaseAlreadyExistsException ex)
            {
                throw new UserFriendlyException(StringLocalizer[ex.Code, input.Name]);
            }
            
        }

        [Authorize(HariomPermissions.Diseases.Edit)]
        public override async Task<DiseaseDto> UpdateAsync(Guid id, CreateUpdateDiseaseDto input)
        {
            try
            {
                var disease = await _diseaseRepository.GetAsync(id);

                if (disease.Name != input.Name)
                {
                    await _diseaseManager.ChangeNameAsync(disease, input.Name);
                }

                return ObjectMapper.Map<Disease, DiseaseDto>(disease);
            }
            catch (DiseaseAlreadyExistsException ex)
            {
                throw new UserFriendlyException(StringLocalizer[ex.Code, input.Name]);
            }
        }
    }
}
