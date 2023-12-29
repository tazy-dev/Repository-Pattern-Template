
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using Repository_Pattern_Template.Models;

namespace Repository_Pattern_Template.Data
{
    public class StudentDatabaseContext : DbContext
    {
        public StudentDatabaseContext(DbContextOptions options) : base(options) 
        {
          
        }
        //public static StudentDatabaseContext Create(IMongoDatabase database) =>
        //new(new DbContextOptionsBuilder<StudentDatabaseContext>()
        //    .UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
        //    .Options);
        public DbSet<Student> Students { get; init; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Student>().ToCollection("students"); ;
        }
    }
}
