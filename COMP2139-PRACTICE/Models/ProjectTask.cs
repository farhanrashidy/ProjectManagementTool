using System.ComponentModel.DataAnnotations;

namespace COMP2139_PRACTICE.Models;

public class ProjectTask
{
    [Key]
    public int TaskId { get; set; }
    
    [Required]
    public required string Title {get; set;}
    
    [Required]
    public string Description {get; set;}
    
    [Required]
    public string Status {get; set;}
    
    // Foreign Key
    public int ProjectId { get; set; }
    
    // Navigation property
    // This property allows for easy access to the related Project entity from the Task enity
    public Project? Project { get; set; }
    
    
}