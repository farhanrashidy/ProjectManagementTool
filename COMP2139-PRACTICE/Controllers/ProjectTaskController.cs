using COMP2139_PRACTICE.Data;
using COMP2139_PRACTICE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace COMP2139_PRACTICE.Controllers;

public class ProjectTaskController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProjectTaskController(ApplicationDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public IActionResult Index(int projectId)
    {
        var tasks = _context
            .ProjectTasks
            .Where(t => t.ProjectId == projectId)
            .ToList();
        ViewBag.ProjectId = projectId;
        return View(tasks);
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var task = _context
            .ProjectTasks
            .Include(t => t.Project)
            .FirstOrDefault(t => t.TaskId == id);
        if (task == null)
        {
            return NotFound();
        }
        return View(task);
    }

    [HttpGet]
    public IActionResult Create(int projectId)
    {
        var project = _context.Projects.Find(projectId);
        if (project == null)
        {
            return NotFound();
        }

        
        var task = new ProjectTask
        {
            ProjectId = projectId,
            Title = "",
            Description = "",
            Status = ""
            
        };
        return View(task);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind ("Title", "Description", "ProjectId", "Status")] ProjectTask task)
    {
        if (ModelState.IsValid)
        {
            _context.ProjectTasks.Add(task);
            _context.SaveChanges();
            return RedirectToAction("Index", new{projectId = task.ProjectId});
        }
        return View(task);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var task = _context
            .ProjectTasks
            .Include(t => t.Project)
            .FirstOrDefault(t => t.TaskId == id);
        if (task == null)
        {
            return NotFound();
        }
        return View(task);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("TaskId", "Title", "Description", "ProjectId", "Status")] ProjectTask task)
    {
        if (id != task.TaskId)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            _context.ProjectTasks.Update(task);
            _context.SaveChanges();
            return RedirectToAction("Index", new{projectId = task.ProjectId});
        }
        return View(task);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var task = _context
            .ProjectTasks
            .Include(t => t.Project)
            .FirstOrDefault(t => t.TaskId == id);
        if (task == null)
        {
            return NotFound();
        }
        return View(task);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int taskId)
    {
        var task = _context.ProjectTasks.Find(taskId);
        if (task != null)
        {
            _context.ProjectTasks.Remove(task);
            _context.SaveChanges();
            return RedirectToAction("Index", new{projectId = task.ProjectId});
            
        }

        return View(task);

    }
    
}