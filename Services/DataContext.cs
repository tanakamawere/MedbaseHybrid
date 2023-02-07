using MedbaseHybrid.Models;
using Microsoft.EntityFrameworkCore;

namespace MedbaseHybrid.Services
{
    public class DataContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<QuestionPack> QuestionPacks { get; set; }

        public DataContext()
        {
            SQLitePCL.Batteries_V2.Init();

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "medbasedfhvpmkofdjskgjdfagfhd.db3");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
