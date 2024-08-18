using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hariom.Diseases
{
    public interface IDiseaseAppService :
        ICrudAppService< //Defines CRUD methods
        DiseaseDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateDiseaseDto> //Used to create/update a book
    {
    }
}
