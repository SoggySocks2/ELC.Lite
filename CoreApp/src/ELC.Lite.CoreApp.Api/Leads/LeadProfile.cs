using AutoMapper;
using ELC.Lite.Domain.Leads;
using ELC.Lite.Models.Leads;

namespace ELC.Lite.CoreApp.Api.Leads
{
    public class LeadProfile : Profile
    {
        public LeadProfile()
        {
            CreateMap<Lead, LeadModel>()
            .ForMember(dest => dest.Budget, opt => opt.MapFrom(src => src.Budget))
            .ForMember(dest => dest.Forenames, opt => opt.MapFrom(src => src.Customer.Forenames))
            .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Customer.Surname))
            .ForMember(dest => dest.TelNo, opt => opt.MapFrom(src => src.Customer.TelNo))
            .ForMember(dest => dest.Postcode, opt => opt.MapFrom(src => src.Customer.Postcode))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Customer.Address))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Customer.Email))

            .ForMember(dest => dest.CurrentVehicleMake, opt => opt.MapFrom(src => src.CurrentVehicle.Make))
            .ForMember(dest => dest.CurrentVehicleModel, opt => opt.MapFrom(src => src.CurrentVehicle.Model))
            .ForMember(dest => dest.CurrentVehicleYear, opt => opt.MapFrom(src => src.CurrentVehicle.Year))

            .ForMember(dest => dest.InterestedInVehicleMake, opt => opt.MapFrom(src => src.InterestedInVehicle.Make))
            .ForMember(dest => dest.InterestedInVehicleModel, opt => opt.MapFrom(src => src.InterestedInVehicle.Model));
        }
    }
}