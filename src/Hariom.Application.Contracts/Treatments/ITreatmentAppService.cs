using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hariom.Treatments
{
    public interface ITreatmentAppService :
        ICrudAppService< //Defines CRUD methods
        TreatmentDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateTreatmentDto> //Used to create/update a book
    {
    }
}
