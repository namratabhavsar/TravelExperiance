using AutoMapper;
using TravelExperianceManagement.Models.Domain;
using TravelExperianceManagement.Models.DTO;

namespace TravelExperianceManagement.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Trip,TripDto>().ReverseMap();
            CreateMap<Trip, CreateTripRequest>().ReverseMap();
            CreateMap<CreateActivityRequest, Activity>().ReverseMap();
            CreateMap<Trip, TripResponse>().
                ForMember(a=>a.TotalCost,option => option.MapFrom(src => src.Activities.Sum(a=>a.Cost)));
            CreateMap<UpdateTripRequest, Trip>();
        }
    }
}
