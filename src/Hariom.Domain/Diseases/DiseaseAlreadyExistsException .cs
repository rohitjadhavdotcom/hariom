using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Hariom.Diseases
{
    public class DiseaseAlreadyExistsException : BusinessException
    {
        public DiseaseAlreadyExistsException(string name)
        : base(HariomDomainErrorCodes.DiseaseAlreadyExists)
        {
            WithData("name", name);
        }
    }
}
