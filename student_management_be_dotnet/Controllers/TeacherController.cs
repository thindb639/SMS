using System.Data.Common;
using System.Reflection.Metadata.Ecma335;
using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using student_management_be_dotnet.Data;
using student_management_be_dotnet.Models;

namespace student_management_be_dotnet.Controllers;


public class TeacherController(AppDbContext appdbContext) : Controller
{
    public async Task<IActionResult> Index()

    {
        var query = appdbContext.Teachers.AsQueryable();

        var teachers = await query.ToListAsync();

        return View(teachers);

    }

    public IActionResult Create()
    {

        return View();
    }
    // Đưa data vào
    [HttpPost("giao-vien/tao-giao-vien")]
    public async Task<IActionResult> Create(TeacherCreateViewModel model)
    {
        var teacher = new Teacher
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Subject = model.Subject,

        };
        await appdbContext.SaveChangesAsync();
        TempData["Success"]="Đã thêm giáo viên";
        return RedirectToAction(nameof(Index));



    }

}


