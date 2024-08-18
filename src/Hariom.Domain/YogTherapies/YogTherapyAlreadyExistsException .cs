using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Hariom.YogTherapies
{
    public class YogTherapyAlreadyExistsException : BusinessException
    {
        public YogTherapyAlreadyExistsException(string name)
        : base(HariomDomainErrorCodes.YogTherapyAlreadyExists)
        {
            WithData("name", name);
        }
    }
}
