using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj.DataAccess.Entities
{
    public class Question
    {
        public string QuestionText { get; set; }

        public ICollection<Answer> Answers { get; set; }

        public QuestionType Type { get; set; }

        public int Score { get; set; }
    }
}
