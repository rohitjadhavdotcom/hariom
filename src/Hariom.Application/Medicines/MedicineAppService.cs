﻿using Hariom.Diseases;
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
using System.Linq.Dynamic.Core;

namespace Hariom.Medicines
{
    public class MedicineAppService:
        CrudAppService<
        Medicine, //The Book entity
        MedicineDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateMedicineDto>, //Used to create/update a book
        IMedicineAppService //implement the IBookAppService
    {

        private readonly IMedicineRepository _medicineRepository;
        private readonly MedicineManager _medicineManager;
        protected IStringLocalizer<HariomResource> StringLocalizer { get; }

        public MedicineAppService(IRepository<Medicine, Guid> repository, IMedicineRepository medicineRepository, MedicineManager medicineManager, IStringLocalizer<HariomResource> stringLocalizer)
        : base(repository)
        {
            GetPolicyName = HariomPermissions.Medicines.Default;
            GetListPolicyName = HariomPermissions.Medicines.Default;
            CreatePolicyName = HariomPermissions.Medicines.Create;
            UpdatePolicyName = HariomPermissions.Medicines.Edit;
            DeletePolicyName = HariomPermissions.Medicines.Delete;
            _medicineManager = medicineManager;
            _medicineRepository = medicineRepository;
            StringLocalizer = stringLocalizer;
        }

        [Authorize(HariomPermissions.Medicines.Create)]
        public override async Task<MedicineDto> CreateAsync(CreateUpdateMedicineDto input)
        {
            try
            {
                var medicine = await _medicineManager.CreateAsync(
                input.Name);

                await _medicineRepository.InsertAsync(medicine);

                return ObjectMapper.Map<Medicine, MedicineDto>(medicine);
            }
            catch(MedicineAlreadyExistsException ex)
            {
                throw new UserFriendlyException(StringLocalizer[ex.Code, input.Name]);
            }
            
        }

        [Authorize(HariomPermissions.Medicines.Edit)]
        public override async Task<MedicineDto> UpdateAsync(Guid id, CreateUpdateMedicineDto input)
        {
            try
            {
                var medicine = await _medicineRepository.GetAsync(id);

                if (medicine.Name != input.Name)
                {
                    await _medicineManager.ChangeNameAsync(medicine, input.Name);
                }

                return ObjectMapper.Map<Medicine, MedicineDto>(await _medicineRepository.UpdateAsync(medicine));
            }
            catch(MedicineAlreadyExistsException ex)
            {
                throw new UserFriendlyException(StringLocalizer[ex.Code, input.Name]);
            }

        }

        public async Task<PagedResultDto<MedicineDto>> GetListByFilterAsync(PagedAndSortedResultFilterRequestDto input)
        {
            input.SkipCount = 0;
            input.MaxResultCount = 10000;
            var queryable = await _medicineRepository.GetQueryableAsync();
            var query = queryable
                .OrderBy("name")
                .WhereIf(!string.IsNullOrEmpty(input.Filter), i=> i.Name.Contains(input.Filter!) )
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            var queryResult = await AsyncExecuter.ToListAsync(query);
            var totalCount = await Repository.GetCountAsync();

            var medicinesDtos =  ObjectMapper.Map<List<Medicine>, List<MedicineDto>>(queryResult);

            return new PagedResultDto<MedicineDto>(
                totalCount,
                medicinesDtos
            );
        }

    }
}
