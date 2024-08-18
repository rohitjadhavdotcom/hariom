using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Hariom.YogTherapies
{
    public class YogTherapyDto : AuditedEntityDto<Guid>
    {
        public string YogopcharCategory { get; set; } = null!;
        public string YogopcharTherapy { get; set; } = null!;
    }
}
