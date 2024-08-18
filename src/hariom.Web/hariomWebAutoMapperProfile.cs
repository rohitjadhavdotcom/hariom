using AutoMapper;
using Hariom.Diseases;
using Hariom.Mantras;
using Hariom.Medicines;

namespace Hariom.Web;

public class HariomWebAutoMapperProfile : Profile
{
    public HariomWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<DiseaseDto, CreateUpdateDiseaseDto>();
        CreateMap<MedicineDto, CreateUpdateMedicineDto>();
        CreateMap<MantraDto, CreateUpdateMantraDto>();
    }
}
