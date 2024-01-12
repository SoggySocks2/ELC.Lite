using ELC.Lite.Domain.Customers;
using ELC.Lite.Domain.Vehicles;
using ELC.Lite.SharedKernel.Exceptions.Helpers;

namespace ELC.Lite.Domain.Leads
{
    public class Lead
    {
        public int Id { get; private set; }
        public DateTime Created { get; private set; }
        public decimal? Budget { get; private set; } = null!;
        public Customer Customer { get; private set; } = null!;
        public CurrentVehicle CurrentVehicle { get; private set; } = null!;
        public InterestedInVehicle InterestedInVehicle { get; private set; } = null!;

        private Lead() { }

        public Lead(decimal? budget, Customer customer, CurrentVehicle currentVehicle, InterestedInVehicle interestedInVehicle)
        {
            SetBudget(budget);
            SetCustomer(customer);
            SetCurrentVehicle(currentVehicle);
            SetInterestedInVehicle(interestedInVehicle);
        }
        public void SetBudget(decimal? budget)
        {
            Budget = budget;
        }
        public void SetCustomer(Customer customer)
        {
            Check.For.Null(customer);
            Customer = customer;
        }
        public void SetCurrentVehicle(CurrentVehicle currentVehicle)
        {
            Check.For.Null(currentVehicle);
            CurrentVehicle = currentVehicle;
        }
        public void SetInterestedInVehicle(InterestedInVehicle interestedInVehicle)
        {
            Check.For.Null(interestedInVehicle);
            InterestedInVehicle = interestedInVehicle;
        }
    }
}
