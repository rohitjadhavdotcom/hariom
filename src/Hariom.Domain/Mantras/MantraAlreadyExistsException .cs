using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Hariom.Mantras
{
    public class MantraAlreadyExistsException : BusinessException
    {
        public MantraAlreadyExistsException(string name)
        : base(HariomDomainErrorCodes.MantraAlreadyExists)
        {
            WithData("name", name);
        }
    }
}
