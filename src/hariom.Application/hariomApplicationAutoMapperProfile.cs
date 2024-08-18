using AutoMapper;
using Hariom.Diseases;
using Hariom.Mantras;
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

        CreateMap<Mantra, MantraDto>();
        CreateMap<CreateUpdateMantraDto, Mantra>();
    }
}
