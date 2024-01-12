using ELC.Lite.SharedKernel.Exceptions.Helpers;

namespace ELC.Lite.Domain.Vehicles
{
    public class CurrentVehicle
    {
        public string Make { get; private set; } = string.Empty;
        public string Model { get; private set; } = string.Empty;
        public int? Year { get; private set; } = null!;

        private CurrentVehicle() { }

        public CurrentVehicle(string make, string model, int? year)
        {
            SetMake(make);
            SetModel(model);
            SetYear(year);
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

        public void SetYear(int? year)
        {
            Year = year;
        }
    }
}
