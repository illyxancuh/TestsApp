using System.Collections.Generic;
using TestProj.DataAccess.Attributes;

namespace TestProj.DataAccess.Entities
{
    [CollectionName("Tests")]
    public class Test : MongoEntityBase
    {
        public string Name { get; set; }
        
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<Question> Questions { get; set; }

        public Test()
        {
            Questions = new List<Question>();
        }
    }
}
