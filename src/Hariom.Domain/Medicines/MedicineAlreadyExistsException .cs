using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Hariom.Medicines
{
    public class MedicineAlreadyExistsException : BusinessException
    {
        public MedicineAlreadyExistsException(string name)
        : base(HariomDomainErrorCodes.MedicineAlreadyExists)
        {
            WithData("name", name);
        }
    }
}
