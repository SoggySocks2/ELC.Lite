using AutoMapper;
using ELC.Lite.Domain.Customers;
using ELC.Lite.Domain.Leads;
using ELC.Lite.Domain.Vehicles;
using ELC.Lite.Models.Leads;

namespace ELC.Lite.CoreApp.Api.Leads
{
    public class LeadReverseProfile : Profile
    {
        public LeadReverseProfile()
        {
            CreateMap<LeadCreateModel, Lead>()
                .ConvertUsing((src, dest) =>
                {
                    if (dest is null)
                    {
                        var customer = new Customer(src.Forenames, src.Surname, src.TelNo, src.Postcode, src.Address, src.Email);
                        var currentVehicle = new CurrentVehicle(src.CurrentVehicleMake, src.CurrentVehicleModel, src.CurrentVehicleYear);
                        var interestedInVehicle = new InterestedInVehicle(src.InterestedInVehicleMake, src.InterestedInVehicleModel);
                        return new Lead(src.Budget, customer, currentVehicle, interestedInVehicle);
                    }

                    throw new NotImplementedException();
                });

            CreateMap<LeadUpdateModel, Lead>()
                .ConvertUsing((src, dest) =>
                {
                    if (dest is null)
                    {
                        throw new NotImplementedException();
                    }

                    var customer = new Customer(src.Forenames, src.Surname, src.TelNo, src.Postcode, src.Address, src.Email);
                    var currentVehicle = new CurrentVehicle(src.CurrentVehicleMake, src.CurrentVehicleModel, src.CurrentVehicleYear);
                    var interestedInVehicle = new InterestedInVehicle(src.InterestedInVehicleMake, src.InterestedInVehicleModel);

                    dest.SetBudget(src.Budget);
                    dest.SetCustomer(customer);
                    dest.SetCurrentVehicle(currentVehicle);
                    dest.SetInterestedInVehicle(interestedInVehicle);
                    return dest;
                });
        }
    }
}
