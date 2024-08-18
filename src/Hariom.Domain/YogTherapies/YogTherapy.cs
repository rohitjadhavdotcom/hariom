using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hariom.YogTherapies
{
    public class YogTherapy : AuditedAggregateRoot<Guid>
    {
        public string YogopcharCategory { get; set; } = null!;
        public string YogopcharTherapy { get; set; } = null!;

        private YogTherapy()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal YogTherapy(
            Guid id,
            string yogopcharCategory,
            string yogopcharTherapy)
            : base(id)
        {
            Set(yogopcharCategory, yogopcharTherapy);
        }

        internal YogTherapy ChangeYogopachar(string yogopcharCategory,
            string yogopcharTherapy)
        {
            Set(yogopcharCategory, yogopcharTherapy);
            return this;
        }

        private void Set(string yogopcharCategory,
            string yogopcharTherapy)
        {
            YogopcharCategory = Check.NotNullOrWhiteSpace(
                yogopcharCategory,
                nameof(yogopcharCategory),
                maxLength: YogTherapyConsts.MaxNameLength
            );
            YogopcharTherapy = Check.NotNullOrWhiteSpace(
                yogopcharTherapy,
                nameof(yogopcharTherapy),
                maxLength: YogTherapyConsts.MaxNameLength
            );
        }
    }
}
