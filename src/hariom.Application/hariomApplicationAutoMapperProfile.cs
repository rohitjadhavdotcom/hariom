using AutoMapper;
using Hariom.Diseases;

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
    }
}
