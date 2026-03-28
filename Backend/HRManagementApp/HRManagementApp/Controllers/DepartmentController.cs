using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HRManagementApp.Core.Interfaces;
using HRManagementApp.Business.DTOs;
using HRManagementApp.Models;

namespace HRManagementApp.Controllers;

public class DepartmentController : Controller
{
    private readonly IHumanResourceManager _manager;

    public DepartmentController(IHumanResourceManager manager)
    {
        _manager = manager;
    }

    public IActionResult Index()
    {
        var departments = _manager.GetDepartments();
        return View(departments);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new DepartmentDto());
    }

    [HttpPost]
    public IActionResult Create(DepartmentDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }

        try
        {
            _manager.AddDepartment(dto.Name, dto.WorkerLimit, dto.SalaryLimit);
            TempData["SuccessMessage"] = "Department created successfully!";
            return RedirectToAction(nameof(Index));
        }
        catch (System.Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return View(dto);
        }
    }

    [HttpGet]
    public IActionResult Edit(string name)
    {
        if (string.IsNullOrEmpty(name)) return BadRequest();

        var dept = _manager.GetDepartments().FirstOrDefault(d => d.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));
        if (dept == null)
        {
            return NotFound();
        }

        var model = new EditDepartmentViewModel
        {
            OldName = dept.Name,
            NewName = dept.Name
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult Edit(EditDepartmentViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        try
        {
            _manager.EditDepartments(model.OldName, model.NewName);
            TempData["SuccessMessage"] = $"Department name updated to: {model.NewName}";
            return RedirectToAction(nameof(Index));
        }
        catch (System.Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return View(model);
        }
    }
}
