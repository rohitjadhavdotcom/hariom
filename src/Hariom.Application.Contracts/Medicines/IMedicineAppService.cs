﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hariom.Medicines
{
    public interface IMedicineAppService :
        ICrudAppService< //Defines CRUD methods
        MedicineDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateMedicineDto> //Used to create/update a book
    {
    }
}
