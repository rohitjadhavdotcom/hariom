using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hariom.YogTherapies
{
    public class CreateUpdateYogTherapyDto
    {
        [Required]
        [StringLength(500)]
        public string YogopcharCategory { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string YogopcharTherapy { get; set; } = string.Empty;
    }
}
