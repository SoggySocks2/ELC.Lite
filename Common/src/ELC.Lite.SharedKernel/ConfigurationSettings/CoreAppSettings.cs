namespace ELC.Lite.SharedKernel.ConfigurationSettings
{
    public class CoreAppSettings
    {
        public const string CONFIG_NAME = "CoreAppModule";

        public static CoreAppSettings Instance { get; } = new CoreAppSettings();
        private CoreAppSettings() { }

        public bool DisableAzureKeyVault { get; set; }
        public string AzureKeyVaultUrl { get; set; } = string.Empty;
        public string AzureKeyVaultSecretKey { get; set; } = string.Empty;
        public string DbConnectionString { get; set; } = string.Empty;
        public int? DbTimeout { get; set; } = 30;
    }
}
