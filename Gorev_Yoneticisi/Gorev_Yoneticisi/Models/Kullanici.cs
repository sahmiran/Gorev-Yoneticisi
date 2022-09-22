using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Gorev_Yoneticisi.Models
{
    [BsonIgnoreExtraElements]
    public class Kullanici
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        [BsonElement("fullname")]
        public string Fullname { get; set; } = string.Empty;
        [BsonElement("gunlukhedef")]
        public string GunlukHedef { get; set; } = string.Empty;
        [BsonElement("haftalikhedef")]
        public string HaftalikHedef { get; set; } = string.Empty;
        [BsonElement("aylikhedef")]
        public string AylikHedef { get; set; } = string.Empty;

    }
}
