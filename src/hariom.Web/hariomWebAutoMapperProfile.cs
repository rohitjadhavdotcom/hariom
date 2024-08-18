using AutoMapper;
using Hariom.Diseases;

namespace Hariom.Web;

public class HariomWebAutoMapperProfile : Profile
{
    public HariomWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<DiseaseDto, CreateUpdateDiseaseDto>();
    }
}
