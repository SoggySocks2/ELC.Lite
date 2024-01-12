namespace ELC.Lite.Models.Leads
{
    public record LeadModel
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public decimal? Budget { get; set; } = null!;
        public string Forenames { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string TelNo { get; set; } = string.Empty;
        public string Postcode { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string CurrentVehicleMake { get; set; } = string.Empty;
        public string CurrentVehicleModel { get; set; } = string.Empty;
        public int? CurrentVehicleYear { get; set; }
        public string InterestedInVehicleMake { get; set; } = string.Empty;
        public string InterestedInVehicleModel { get; set; } = string.Empty;
    }
}
