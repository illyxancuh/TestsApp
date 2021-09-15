using System.Collections.Generic;
using TestProj.DataAccess.Attributes;

namespace TestProj.DataAccess.Entities
{
    [CollectionName("Users")]
    public class User : MongoEntityBase
    {
        public string Login { get; set; }

        public string PasswordHash { get; set; }

        public ICollection<Test> Tests { get; set; }
    }
}