using Microsoft.EntityFrameworkCore;
using TestProj.DataAccess.Entities;

namespace TestProj.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<UserTest> UserTests { get; set; }
        public DbSet<UserTestSession> UserTestSessions {  get; set; }
        public DbSet<UserTestResult> UserTestResults {  get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            :base(options)
        {
            Database.Migrate();
        }
    }
}
