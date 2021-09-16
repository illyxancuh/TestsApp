using System.Collections.Generic;

namespace TestProj.DataAccess.Entities
{
    public class Question : EntityBase
    {
        public int TestId { get; set; }

        public string QuestionText { get; set; }

        public QuestionType Type { get; set; }

        public int Score { get; set; }

        public int Position { get; set; }

        public ICollection<Answer> Answers { get; set; }

        public Test Test { get; set; }
    }
}
