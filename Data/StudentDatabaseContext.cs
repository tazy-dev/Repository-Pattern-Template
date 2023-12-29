using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;
using Repository_Pattern_Template.Models;

namespace Repository_Pattern_Template.Data
{
    public class StudentDatabaseContext : DbContext
    {
        public StudentDatabaseContext(DbContextOptions options) : base(options) 
        {
        }
        
        public DbSet<Student> Students { get; init; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Student>().ToCollection("students"); ;
        }
    }
}
