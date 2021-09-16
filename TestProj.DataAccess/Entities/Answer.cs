namespace TestProj.DataAccess.Entities
{
    public class Answer : EntityBase
    {
        public int QuestionId { get; set; }

        public string AnswerText { get; set; }

        public bool IsCorrect { get; set; }

        public Question Question { get; set; }
    }
}
