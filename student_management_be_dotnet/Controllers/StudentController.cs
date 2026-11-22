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
    public async Task<IActionResult> Index([FromQuery]StudentFilter filter)
    {
        var student = await appDbContext
            .Students
            .Where(student => student.FirstName == filter.Search )
            .Include(student => student.Class)
            .ToListAsync();

        return View(new StudentIndexViewModel
        {
            Students = student,
        });
    }
//Màn hình
    [HttpGet("sinh-vien/tao-sinh-vien")]
    public async Task<IActionResult> Create()
    {

        return View();
    }
//Đưa data vào
    [HttpPost("sinh-vien/tao-sinh-vien")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(StudentCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var student = appDbContext.Students.Add(new Models.Student
        {
            ClassId = model.ClassId,
            LastName = model.LastName,
            DateOfBirth = model.DateOfBirth,
            FirstName = model.FirstName,
            Code = model.Code,
            Email = model.Email,
            IdentificationNumber = model.IdentificationNumber,
        });
        await appDbContext.SaveChangesAsync();

        TempData["Success"] = "Đã thêm lớp";
        return RedirectToAction(nameof(Index));

        

    }

    
}