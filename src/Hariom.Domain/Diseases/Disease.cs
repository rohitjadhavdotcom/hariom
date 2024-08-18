using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hariom.Diseases
{
    public class Disease : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; } = null!;

        private Disease()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal Disease(
            Guid id,
            string name)
            : base(id)
        {
            SetName(name);
        }

        internal Disease ChangeName(string name)
        {
            SetName(name);
            return this;
        }

        private void SetName(string name)
        {
            Name = Check.NotNullOrWhiteSpace(
                name,
                nameof(name),
                maxLength: DiseaseConsts.MaxNameLength
            );
        }
    }
}
