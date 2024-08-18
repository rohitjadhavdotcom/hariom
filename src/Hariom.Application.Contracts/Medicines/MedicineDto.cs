using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Hariom.Medicines
{
    public class MedicineDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; } = null!;
    }
}
