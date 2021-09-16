namespace TestProj.Application.DTOs
{
    public class SubmitAnswerResultDTO
    {
        public bool TestFinished { get; set; }
        public int? NextQuestionId { get; set; }
        public int? TestResultId { get; set; }
    }
}
