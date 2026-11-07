using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using student_management_be_dotnet.Data;
using student_management_be_dotnet.ViewModels.Classes;
using student_management_be_dotnet.ViewModels.Student;

namespace student_management_be_dotnet.Controllers;

public class StudentController(AppDbContext appDbContext) : Controller
{
//Lấy data ra
    [HttpGet("sinh-vien/danh-sach")]
    public async Task<IActionResult> Index()
    {
        var student = await appDbContext
            .Students
            .Include(student => student.Class)
            .ToListAsync();

        return View(student);
    }
//Màn hình
    [HttpGet("sinh-vien/tao-sinh-vien")]
    public async Task<IActionResult> Create()
    {

        return View();
    }
//Đưa data vào
    [HttpPost("sinh-vien/tao-sinh-vien")]
    public async Task<IActionResult> Create(StudentCreateViewModel model)
    {
        var student = appDbContext.Students.Add(new Models.Student
        {
            ClassId = model.ClassId,
            Name = model.Name,
            Email = model.Email,
        });
        await appDbContext.SaveChangesAsync();

        TempData["Success"] = "Đã thêm lớp";
        return RedirectToAction(nameof(Index));
    }

}