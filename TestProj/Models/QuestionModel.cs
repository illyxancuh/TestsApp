using System.Collections.Generic;

namespace TestProj.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }

        public string QuestionText { get; set; }

        public ICollection<AnswerModel> Answers { get; set; }

        public QuestionTypeModel Type { get; set; }
    }
}
