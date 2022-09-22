namespace Gorev_Yoneticisi.Models
{
    public class KullaniciDatabaseSettings : IKullaniciDatabaseSettings
    {
        public string KullaniciCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
