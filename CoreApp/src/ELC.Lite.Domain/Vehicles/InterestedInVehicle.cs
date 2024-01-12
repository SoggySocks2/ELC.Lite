using ELC.Lite.SharedKernel.Exceptions.Helpers;

namespace ELC.Lite.Domain.Vehicles
{
    public class InterestedInVehicle
    {
        public string Make { get; private set; } = string.Empty;
        public string Model { get; private set; } = string.Empty;

        private InterestedInVehicle() { }
        public InterestedInVehicle(string make, string model)
        {
            SetMake(make);
            SetModel(model);
        }

        public void SetMake(string make)
        {
            Check.For.NullOrWhiteSpace(make);
            Make = make;
        }
        public void SetModel(string model)
        {
            Check.For.NullOrWhiteSpace(model);
            Model = model;
        }
    }
}
