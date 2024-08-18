using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Hariom.Diseases
{
    public class DiseaseDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; } = null!;
    }
}
