using Microsoft.EntityFrameworkCore;
using EmployeeManagement.API.Model;

namespace EmployeeManagement.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<User> ApplicationUsers { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            base.OnModelCreating(modelBuilder);

            // Department -> Employee (Optional)

            modelBuilder.Entity<Employee>()

                .HasOne(e => e.Department)

                .WithMany(d => d.Employees)

                .HasForeignKey(e => e.DepartmentID);

            // Composite Primary Key

            modelBuilder.Entity<EmployeeSkill>()

                .HasKey(es => new { es.EmployeeID, es.SkillID });

            // Employee -> EmployeeSkill

            modelBuilder.Entity<EmployeeSkill>()

                .HasOne(es => es.Employee)

                .WithMany(e => e.EmployeeSkills)

                .HasForeignKey(es => es.EmployeeID);

            // Skill -> EmployeeSkill

            modelBuilder.Entity<EmployeeSkill>()

                .HasOne(es => es.Skill)

                .WithMany(s => s.EmployeeSkills)

                .HasForeignKey(es => es.SkillID);

        }


    }
}