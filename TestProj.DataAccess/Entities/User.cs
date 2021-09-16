using System.Collections.Generic;

namespace TestProj.DataAccess.Entities
{
    public class User : EntityBase
    {
        public string Login { get; set; }

        public string PasswordHash { get; set; }

        public ICollection<UserTest> Tests { get; set; }
    }
}