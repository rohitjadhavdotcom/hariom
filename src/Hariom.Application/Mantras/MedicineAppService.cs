using Hariom.Diseases;
using Hariom.Localization;
using Hariom.Permissions;
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

namespace Hariom.Mantras
{
    public class MantraAppService:
        CrudAppService<
        Mantra, //The Book entity
        MantraDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateMantraDto>, //Used to create/update a book
        IMantraAppService //implement the IBookAppService
    {

        private readonly IMantraRepository _mantraRepository;
        private readonly MantraManager _mantraManager;
        protected IStringLocalizer<HariomResource> StringLocalizer { get; }

        public MantraAppService(IRepository<Mantra, Guid> repository, IMantraRepository mantraRepository, MantraManager mantraManager, IStringLocalizer<HariomResource> stringLocalizer)
        : base(repository)
        {
            GetPolicyName = HariomPermissions.Mantras.Default;
            GetListPolicyName = HariomPermissions.Mantras.Default;
            CreatePolicyName = HariomPermissions.Mantras.Create;
            UpdatePolicyName = HariomPermissions.Mantras.Edit;
            DeletePolicyName = HariomPermissions.Mantras.Delete;
            _mantraManager = mantraManager;
            _mantraRepository = mantraRepository;
            StringLocalizer = stringLocalizer;
        }

        [Authorize(HariomPermissions.Mantras.Create)]
        public override async Task<MantraDto> CreateAsync(CreateUpdateMantraDto input)
        {
            try
            {
                var mantra = await _mantraManager.CreateAsync(
                input.Name);

                await _mantraRepository.InsertAsync(mantra);

                return ObjectMapper.Map<Mantra, MantraDto>(mantra);
            }
            catch(MantraAlreadyExistsException ex)
            {
                throw new UserFriendlyException(StringLocalizer[ex.Code, input.Name]);
            }
            
        }

        [Authorize(HariomPermissions.Mantras.Edit)]
        public override async Task<MantraDto> UpdateAsync(Guid id, CreateUpdateMantraDto input)
        {
            try
            {
                var mantra = await _mantraRepository.GetAsync(id);

                if (mantra.Name != input.Name)
                {
                    await _mantraManager.ChangeNameAsync(mantra, input.Name);
                }

                return ObjectMapper.Map<Mantra, MantraDto>(await _mantraRepository.UpdateAsync(mantra));
            }
            catch(MantraAlreadyExistsException ex)
            {
                throw new UserFriendlyException(StringLocalizer[ex.Code, input.Name]);
            }

        }

        public override async Task<PagedResultDto<MantraDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            input.SkipCount = 0;
            input.MaxResultCount = 10000;
            return await base.GetListAsync(input);
        }

    }
}
