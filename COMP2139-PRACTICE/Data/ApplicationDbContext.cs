using COMP2139_PRACTICE.Models;
using Microsoft.EntityFrameworkCore;

namespace COMP2139_PRACTICE.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Project> Projects { get; set; }
}