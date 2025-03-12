using COMP2139_PRACTICE.Models;
using Microsoft.EntityFrameworkCore;

namespace COMP2139_PRACTICE.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){ }
    
    public DbSet<Project> Projects { get; set; }
    
    public DbSet<ProjectTask> ProjectTasks { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>()
            .HasMany(p => p.Tasks)
            .WithOne(t => t.Project)
            .HasForeignKey(t => t.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);
        
        //Seeding the database
        modelBuilder.Entity<Project>().HasData(
            new Project
            {
                ProjectId = 1, 
                Name = "Assignment 3", 
                Description = "COMP 2139", 
                StartDate = DateTime.Today,
                EndDate = DateTime.Today, 
                Status = "Pending"
            },
            new Project
            {
                ProjectId = 2, 
                Name = "Assignment 4", 
                Description = "COMP 2139 - Assignment 4", 
                StartDate = DateTime.Today,
                EndDate = DateTime.Today, 
                Status = "Pending"
            });
        
        modelBuilder.Entity<Project>()
            .Property(p => p.StartDate)
            .HasConversion(v => v.ToUniversalTime(), v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

        modelBuilder.Entity<Project>()
            .Property(p => p.EndDate)
            .HasConversion(v => v.ToUniversalTime(), v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
    }

    

}