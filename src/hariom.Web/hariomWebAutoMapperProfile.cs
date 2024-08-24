using AutoMapper;
using Hariom.Diseases;
using Hariom.Mantras;
using Hariom.Medicines;
using Hariom.Treatments;
using Hariom.YogTherapies;

namespace Hariom.Web;

public class HariomWebAutoMapperProfile : Profile
{
    public HariomWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<DiseaseDto, CreateUpdateDiseaseDto>();
        CreateMap<MedicineDto, CreateUpdateMedicineDto>();
        CreateMap<MantraDto, CreateUpdateMantraDto>();
        CreateMap<YogTherapyDto, CreateUpdateYogTherapyDto>();
        CreateMap<TreatmentDto, CreateUpdateTreatmentDto>();
    }
}
