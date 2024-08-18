using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Hariom.Mantras
{
    public class MantraManager : DomainService
    {
        private readonly IMantraRepository _mantraRepository;

        public MantraManager(IMantraRepository mantraRepository)
        {
            _mantraRepository = mantraRepository;
        }

        public async Task<Mantra> CreateAsync(string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var existingAuthor = await _mantraRepository.FindByNameAsync(name);
            if (existingAuthor != null)
            {
                throw new MantraAlreadyExistsException(name);
            }

            return new Mantra(GuidGenerator.Create(), name);
        }

        public async Task ChangeNameAsync(Mantra mantra, string newName)
        {
            Check.NotNull(mantra, nameof(mantra));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));

            var existingMantra = await _mantraRepository.FindByNameAsync(newName);
            if (existingMantra != null && existingMantra.Id != mantra.Id)
            {
                throw new MantraAlreadyExistsException(newName);
            }

            mantra.ChangeName(newName);
        }
    }
}
