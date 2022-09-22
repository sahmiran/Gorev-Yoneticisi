using Gorev_Yoneticisi.Models;
namespace Gorev_Yoneticisi.Services
{
    public interface IKullaniciService
    {
        List<Kullanici> Get();
        Kullanici Get(string id);
        Kullanici Create(Kullanici kullanici);
        void Remove(string id);
        void Update(string id, Kullanici kullanici);


    }
}
