using System;

namespace TestProj.DataAccess.Entities
{
    public class UserTestResult : EntityBase
    {
        public int UserId { get; set; }

        public int TestId { get; set; }

        public float Score { get; set; }

        public bool IsPassed { get; set; }

        public DateTime CompletionTime { get; set; }

        public User User { get; set; }

        public Test Test { get; set; }
    }
}
