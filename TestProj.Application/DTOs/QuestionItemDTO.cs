namespace TestProj.Application.DTOs
{
    public class QuestionItemDTO
    {
        public int TestId { get; set; }
        public QuestionDTO Question { get; set; }
        public int CurrentNumber { get; set; }
        public int TotalCount { get; set; }
    }
}
