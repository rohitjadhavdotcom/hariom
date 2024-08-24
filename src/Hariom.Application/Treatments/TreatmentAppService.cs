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

        public TreatmentAppService(IRepository<Treatment, Guid> repository, ITreatmentRepository treatmentRepository, TreatmentManager treatmentManager, IStringLocalizer<HariomResource> stringLocalizer)
        : base(repository)
        {
            GetPolicyName = HariomPermissions.Treatments.Default;
            GetListPolicyName = HariomPermissions.Treatments.Default;
            CreatePolicyName = HariomPermissions.Treatments.Create;
            UpdatePolicyName = HariomPermissions.Treatments.Edit;
            DeletePolicyName = HariomPermissions.Treatments.Delete;
            StringLocalizer = stringLocalizer;
        }

    }
}
