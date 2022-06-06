using ApplicationApi.Models;
using AutoMapper;

namespace ApplicationApi.Data.MapperProfiles
{
    public class ApplicatonProfile : Profile
    {
        public ApplicatonProfile()
        {
            CreateMap<Application, ApplicationModel>();
            CreateMap<ApplicationModel, Application>();
        }
    }
}
