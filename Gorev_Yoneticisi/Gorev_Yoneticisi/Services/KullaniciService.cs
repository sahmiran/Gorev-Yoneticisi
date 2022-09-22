using Gorev_Yoneticisi.Models;
using MongoDB.Driver;

namespace Gorev_Yoneticisi.Services
{
    
    public class KullaniciService : IKullaniciService
    {
        private readonly IMongoCollection<Kullanici> _kullanici;

        public KullaniciService(IKullaniciDatabaseSettings settings, IMongoClient mongoClient)
        {
           var database = mongoClient.GetDatabase(settings.DatabaseName);
           _kullanici = database.GetCollection<Kullanici>(settings.KullaniciCollectionName);
        }
        public Kullanici Create(Kullanici kullanici)
        {
            _kullanici.InsertOne(kullanici);
            return kullanici;
        }

        public List<Kullanici> Get()
        {
            return _kullanici.Find(kullanici => true).ToList();
        }

        public Kullanici Get(string id)
        {
            return _kullanici.Find(kullanici => kullanici.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _kullanici.DeleteOne(kullanici => kullanici.Id == id);
        }

        public void Update(string id, Kullanici kullanici)
        {
            _kullanici.ReplaceOne(kullanici => kullanici.Id == id, kullanici);
        }

    }
}
