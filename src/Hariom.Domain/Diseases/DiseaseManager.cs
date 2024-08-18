using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Hariom.Diseases
{
    public class DiseaseManager : DomainService
    {
        private readonly IDiseaseRepository _diseaseRepository;

        public DiseaseManager(IDiseaseRepository diseaseRepository)
        {
            _diseaseRepository = diseaseRepository;
        }

        public async Task<Disease> CreateAsync(
        string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var existingAuthor = await _diseaseRepository.FindByNameAsync(name);
            if (existingAuthor != null)
            {
                throw new DiseaseAlreadyExistsException(name);
            }

            return new Disease(GuidGenerator.Create(), name);
        }

        public async Task ChangeNameAsync(
        Disease disease,
        string newName)
        {
            Check.NotNull(disease, nameof(disease));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));

            var existingDisease = await _diseaseRepository.FindByNameAsync(newName);
            if (existingDisease != null && existingDisease.Id != disease.Id)
            {
                throw new DiseaseAlreadyExistsException(newName);
            }

            disease.ChangeName(newName);
        }
    }
}
