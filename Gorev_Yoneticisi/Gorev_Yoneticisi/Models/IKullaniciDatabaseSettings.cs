namespace Gorev_Yoneticisi.Models
{
    public interface IKullaniciDatabaseSettings
    {
        string KullaniciCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; } 

    }
}
