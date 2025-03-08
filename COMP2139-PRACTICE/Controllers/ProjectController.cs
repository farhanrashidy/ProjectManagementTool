using COMP2139_PRACTICE.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP2139_PRACTICE.Controllers;

public class ProjectController: Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        var projects = new List<Project>
        {
            new Project
            {
                ProjectId = 1, 
                Name = "Project 1", 
                Description = "Project", 
                StartDate = new DateTime(2025, 03, 08), 
                EndDate = new DateTime(2025, 04, 08),
                Status = "In Progress"
            },
        };
        
        return View(projects);
    }
    
    
}