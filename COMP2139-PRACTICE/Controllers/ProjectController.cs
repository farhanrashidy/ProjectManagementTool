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
                Description = "Assignment",
                StartDate = new DateTime(2025, 03, 08),
                EndDate = new DateTime(2025, 04, 08),
                Status = "In Progress"
            },
            new Project{
                ProjectId = 2,
                Name = "Project 2",
                Description = "Lab Project",
                StartDate = new DateTime(2025, 03, 12),
                EndDate = new DateTime(2025, 04, 08),
                Status = "In Progress"
            },
            new Project{
                ProjectId = 2,
                Name = "Project 2",
                Description = "Lab Project",
                StartDate = new DateTime(2025, 03, 12),
                EndDate = new DateTime(2025, 04, 08),
                Status = "In Progress"
            }
        };
        return View(projects);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Project project)
    {
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var project = new Project
        {
            ProjectId = 1,
            Name = "Project 1",
            Description = "Group Assignment worth 20% of your grade",
            StartDate = new DateTime(2025, 03, 08),
            EndDate = new DateTime(2025, 04, 08),
            Status = "In Progress"
        };
        
        return View(project);
    }
    
}