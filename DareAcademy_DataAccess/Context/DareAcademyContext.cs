using DareAcademy_DataAccess.Application;
using DareAcademy_DataAccess.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DareAcademy_DataAccess.Context
{
    public class DareAcademyContext : IdentityDbContext<ApplicationUser>
    {
        public DareAcademyContext(DbContextOptions<DareAcademyContext> options) : base(options) { }
        public DbSet<Category> categories { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Course_Schedule> course_Schedule { get; set; }
        public DbSet<Process> Process { get; set; }
        public DbSet<Section> sections { get; set; }
        public DbSet<Section_Student> section_Student { get; set; }
        public DbSet<Student> student { get; set; }
        public DbSet<Topics> topics { get; set; }
        public DbSet<Plan> plans { get; set; }
        public DbSet<Plan_Item> plan_Item { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Section_Student>().HasKey(OP => new { OP.Section_ID, OP.StudentID });
            modelBuilder.Entity<Plan_Item>().HasKey(OP => new { OP.Course_ID, OP.Plan_ID });
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
