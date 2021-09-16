using System;

namespace TestProj.Application.DTOs
{
    public class UserTestResultDTO
    {
        public int UserId { get; set; }
        public int TestId { get; set; }
        public float Score { get; set; }
        public bool IsPassed { get; set; }
        public DateTime CompletionTime { get; set; }
        public TestSummaryDTO TestSummary { get; set; }
    }
}
