using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj.DataAccess.Entities
{
    public class Test
    {
        public string Name { get; set; }
        
        public string Description { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
