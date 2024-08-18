using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Hariom.Medicines
{
    public class MedicineManager : DomainService
    {
        private readonly IMedicineRepository _medicineRepository;

        public MedicineManager(IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }

        public async Task<Medicine> CreateAsync(string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var existingAuthor = await _medicineRepository.FindByNameAsync(name);
            if (existingAuthor != null)
            {
                throw new MedicineAlreadyExistsException(name);
            }

            return new Medicine(GuidGenerator.Create(), name);
        }

        public async Task ChangeNameAsync(Medicine medicine, string newName)
        {
            Check.NotNull(medicine, nameof(medicine));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));

            var existingMedicine = await _medicineRepository.FindByNameAsync(newName);
            if (existingMedicine != null && existingMedicine.Id != medicine.Id)
            {
                throw new MedicineAlreadyExistsException(newName);
            }

            medicine.ChangeName(newName);
        }
    }
}
