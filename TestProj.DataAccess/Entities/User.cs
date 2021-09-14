using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using TestProj.DataAccess.Attributes;

namespace TestProj.DataAccess.Entities
{
    [CollectionName("Users")]
    public class User
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; }

        public string Login { get; set; }

        public string PasswordHash { get; set; }
    }
}