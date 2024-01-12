using ELC.Lite.SharedKernel.Exceptions.Helpers;

namespace ELC.Lite.Domain.Customers
{
    public class Customer
    {
        public string Forenames { get; private set; } = string.Empty;
        public string Surname { get; private set; } = string.Empty;
        public string TelNo { get; private set; } = string.Empty;
        public string Postcode { get; private set; } = string.Empty;
        public string Address { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;

        public Customer(string forenames, string surname, string telNo, string postcode, string address, string email)
        {
            SetForenames(forenames);
            SetSurname(surname);
            SetTelNo(telNo);
            SetPostcode(postcode);
            SetAddress(address);
            SetEmail(email);
        }

        public void SetForenames(string forenames)
        {
            Check.For.NullOrWhiteSpace(forenames);
            Forenames = forenames;
        }
        public void SetSurname(string surname)
        {
            Check.For.NullOrWhiteSpace(surname);
            Surname = surname;
        }
        public void SetTelNo(string telNo)
        {
            TelNo = telNo;
        }
        public void SetPostcode(string postcode)
        {
            Postcode = postcode;
        }
        public void SetAddress(string address)
        {
            Address = address;
        }
        public void SetEmail(string email)
        {
            Check.For.NullOrWhiteSpace(email);
            Email = email;
        }
    }
}
