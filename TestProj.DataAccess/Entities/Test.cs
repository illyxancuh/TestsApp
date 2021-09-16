using System.Collections.Generic;

namespace TestProj.DataAccess.Entities
{
    public class Test : EntityBase
    {
        public string Name { get; set; }
        
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<Question> Questions { get; set; }

        public int PercentageToPass { get; set; }

        public Test()
        {
            Questions = new List<Question>();
        }
    }
}
