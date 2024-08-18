using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Hariom.YogTherapies
{
    public class YogTherapyManager : DomainService
    {
        private readonly IYogTherapyRepository _yogTherapyRepository;

        public YogTherapyManager(IYogTherapyRepository yogTherapyRepository)
        {
            _yogTherapyRepository = yogTherapyRepository;
        }

        public async Task<YogTherapy> CreateAsync(string yogopcharCategory, string yogopcharTherapy)
        {
            Check.NotNullOrWhiteSpace(yogopcharCategory, nameof(yogopcharCategory));
            Check.NotNullOrWhiteSpace(yogopcharTherapy, nameof(yogopcharTherapy));

            var existingAuthor = await _yogTherapyRepository.FindByYogopcharCategoryAsync(yogopcharCategory);
            if (existingAuthor != null)
            {
                throw new YogTherapyAlreadyExistsException(yogopcharCategory);
            }

            return new YogTherapy(GuidGenerator.Create(), yogopcharCategory, yogopcharTherapy);
        }

        public async Task ChangeYogopacharAsync(YogTherapy yogTherapy, string yogopcharCategory, string yogopcharTherapy)
        {
            Check.NotNull(yogTherapy, nameof(yogTherapy));
            Check.NotNullOrWhiteSpace(yogopcharCategory, nameof(yogopcharCategory));
            Check.NotNullOrWhiteSpace(yogopcharTherapy, nameof(yogopcharTherapy));

            var existingYogTherapy = await _yogTherapyRepository.FindByYogopcharCategoryAsync(yogopcharCategory);
            if (existingYogTherapy != null && existingYogTherapy.Id != yogTherapy.Id)
            {
                throw new YogTherapyAlreadyExistsException(yogopcharCategory);
            }

            yogTherapy.ChangeYogopachar(yogopcharCategory, yogopcharTherapy);
        }
    }
}
