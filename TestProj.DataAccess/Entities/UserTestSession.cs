using System;

namespace TestProj.DataAccess.Entities
{
    public class UserTestSession : EntityBase
    {
        public int UserId { get; set; }

        public int TestId { get; set; }

        public DateTime StartedAt { get; set; }

        public int CurrentQuestionId { get; set; }

        public int CurrentScore {  get; set; }

        public User User { get; set; }

        public Test Test { get; set; }

        public Question CurrentQuestion { get; set; }
    }
}
