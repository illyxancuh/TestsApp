using System;

namespace TestProj.Models
{
    public class TestPassedModel
    {
        public float Score { get; set; }

        public bool IsPassed { get; set; }

        public DateTime CompletionTime { get; set; }

        public TestSummaryModel TestSummary { get; set; }
    }
}
