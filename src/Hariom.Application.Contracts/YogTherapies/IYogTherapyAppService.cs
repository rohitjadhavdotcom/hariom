using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hariom.YogTherapies
{
    public interface IYogTherapyAppService :
        ICrudAppService< //Defines CRUD methods
        YogTherapyDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateYogTherapyDto> //Used to create/update a book
    {
    }
}
