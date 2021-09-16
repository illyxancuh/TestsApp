namespace TestProj.DataAccess.Entities
{
    public class UserTest : EntityBase
    {
        public int UserId { get; set; }

        public int TestId { get; set; }

        public User User { get; set; }

        public Test Test { get; set; }
    }
}
