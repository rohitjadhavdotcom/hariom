using Hariom.Diseases;
using Hariom.Localization;
using Hariom.Medicines;
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
using System.Linq.Dynamic.Core;


namespace Hariom.YogTherapies
{
    public class YogTherapyAppService:
        CrudAppService<
        YogTherapy, //The Book entity
        YogTherapyDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateYogTherapyDto>, //Used to create/update a book
        IYogTherapyAppService //implement the IBookAppService
    {

        private readonly IYogTherapyRepository _yogTherapyRepository;
        private readonly YogTherapyManager _yogTherapyManager;
        protected IStringLocalizer<HariomResource> StringLocalizer { get; }

        public YogTherapyAppService(IRepository<YogTherapy, Guid> repository, IYogTherapyRepository yogTherapyRepository, YogTherapyManager yogTherapyManager, IStringLocalizer<HariomResource> stringLocalizer)
        : base(repository)
        {
            GetPolicyName = HariomPermissions.YogTherapies.Default;
            GetListPolicyName = HariomPermissions.YogTherapies.Default;
            CreatePolicyName = HariomPermissions.YogTherapies.Create;
            UpdatePolicyName = HariomPermissions.YogTherapies.Edit;
            DeletePolicyName = HariomPermissions.YogTherapies.Delete;
            _yogTherapyManager = yogTherapyManager;
            _yogTherapyRepository = yogTherapyRepository;
            StringLocalizer = stringLocalizer;
        }

        [Authorize(HariomPermissions.YogTherapies.Create)]
        public override async Task<YogTherapyDto> CreateAsync(CreateUpdateYogTherapyDto input)
        {
            try
            {
                var yogTherapy = await _yogTherapyManager.CreateAsync(input.YogopcharCategory, input.YogopcharTherapy);

                await _yogTherapyRepository.InsertAsync(yogTherapy);

                return ObjectMapper.Map<YogTherapy, YogTherapyDto>(yogTherapy);
            }
            catch(YogTherapyAlreadyExistsException ex)
            {
                throw new UserFriendlyException(StringLocalizer[ex.Code, input.YogopcharCategory]);
            }
            
        }

        [Authorize(HariomPermissions.YogTherapies.Edit)]
        public override async Task<YogTherapyDto> UpdateAsync(Guid id, CreateUpdateYogTherapyDto input)
        {
            try
            {
                var yogTherapy = await _yogTherapyRepository.GetAsync(id);
                await _yogTherapyManager.ChangeYogopacharAsync(yogTherapy, input.YogopcharCategory, input.YogopcharTherapy);

                return ObjectMapper.Map<YogTherapy, YogTherapyDto>(await _yogTherapyRepository.UpdateAsync(yogTherapy));
            }
            catch(YogTherapyAlreadyExistsException ex)
            {
                throw new UserFriendlyException(StringLocalizer[ex.Code, input.YogopcharCategory]);
            }

        }

        public override async Task<PagedResultDto<YogTherapyDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            input.SkipCount = 0;
            input.MaxResultCount = 10000;
            return await base.GetListAsync(input);
        }

        public async Task<PagedResultDto<YogTherapyDto>> GetListByFilterAsync(PagedAndSortedResultFilterRequestDto input)
        {
            input.SkipCount = 0;
            input.MaxResultCount = 10000;
            var queryable = await _yogTherapyRepository.GetQueryableAsync();
            var query = queryable
                .OrderBy("YogopcharTherapy")
                .WhereIf(!string.IsNullOrEmpty(input.Filter), i => i.YogopcharTherapy.Contains(input.Filter!))
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            var queryResult = await AsyncExecuter.ToListAsync(query);
            var totalCount = await Repository.GetCountAsync();

            var medicinesDtos = ObjectMapper.Map<List<YogTherapy>, List<YogTherapyDto>>(queryResult);

            return new PagedResultDto<YogTherapyDto>(
                totalCount,
                medicinesDtos
            );
        }
    }
}
