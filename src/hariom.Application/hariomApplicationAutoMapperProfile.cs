using AutoMapper;
using Hariom.Diseases;
using Hariom.Medicines;

namespace Hariom;

public class HariomApplicationAutoMapperProfile : Profile
{
    public HariomApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Disease, DiseaseDto>();
        CreateMap<CreateUpdateDiseaseDto, Disease>();

        CreateMap<Medicine, MedicineDto>();
        CreateMap<CreateUpdateMedicineDto, Medicine>();
    }
}
