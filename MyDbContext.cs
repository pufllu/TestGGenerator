using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGGenerator
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("DbConnect")
        {

        }

        public DbSet<Discipline> Discipline { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<TestQuestion> TestQuestions { get; set; }
        public DbSet<ThemeDiscipline> ThemeDisciplines { get; set; }
        public DbSet<TopicTest> TopicTests { get; set; }
    }
}
