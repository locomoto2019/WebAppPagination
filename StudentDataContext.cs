using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAppPagination.Models
{
    public class StudentDataContext : DbContext
    {
        public StudentDataContext() : base(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)
        {
            Database.SetInitializer<StudentDataContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentModel>().ToTable("StudentDetails");
        }

        public DbSet<StudentModel> Student { get; set; }
    }
}