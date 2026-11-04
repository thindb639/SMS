

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using student_management_be_dotnet.Data;

namespace student_management_be_dotnet.Controllers;

public class StudentController(AppDbContext appDbContext) : Controller
{
    public async Task<IActionResult> Index()
    {
        var students = await appDbContext.Students
        .ToListAsync();

        return View(students);
    }

    public IActionResult Create()
    {
        return View();
    }
}
