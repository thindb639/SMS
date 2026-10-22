using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using student_management_be_dotnet.Data;
using student_management_be_dotnet.Models;
using student_management_be_dotnet.ViewModels.Classes;

namespace student_management_be_dotnet.Controllers;

public class ClassesController(AppDbContext dbContext) : Controller
{
    // GET /Classes?Filter.Search=abc&Filter.TeacherId=1
    public async Task<IActionResult> Index([FromQuery] ClassFilter filter)
    {
        var query = dbContext.Classes
            .Include(c => c.Teacher)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(filter.Search))
        {
            var search = filter.Search.Trim();
            query = query.Where(c => c.Name.Contains(search) || c.Code.Contains(search));
        }

        if (filter.TeacherId is not null)
        {
            query = query.Where(c => c.TeacherId == filter.TeacherId);
        }

        var classes = await query
            .OrderBy(c => c.Id)
            .ToListAsync();

        return View(new ClassIndexViewModel
        {
            Filter = filter,
            Classes = classes,
            TeacherOptions = await GetTeacherOptionsAsync(),
        });
    }

    // GET /Classes/Create
    public async Task<IActionResult> Create()
    {
        return View(new ClassCreateViewModel { TeacherOptions = await GetTeacherOptionsAsync() });
    }

    // POST /Classes/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ClassCreateViewModel model)
    {
        var code = model.Code.Trim();

        if (await dbContext.Classes.AnyAsync(c => c.Code == code))
        {
            ModelState.AddModelError(nameof(model.Code), "Mã lớp đã tồn tại");
        }

        if (model.TeacherId is not null && !await dbContext.Teachers.AnyAsync(t => t.Id == model.TeacherId))
        {
            ModelState.AddModelError(nameof(model.TeacherId), "Giáo viên không tồn tại");
        }

        if (!ModelState.IsValid)
        {
            model.TeacherOptions = await GetTeacherOptionsAsync();
            return View(model);
        }

        dbContext.Classes.Add(new Class
        {
            Code = code,
            Name = model.Name.Trim(),
            TeacherId = model.TeacherId,
        });
        await dbContext.SaveChangesAsync();

        TempData["Success"] = "Đã thêm lớp";
        return RedirectToAction(nameof(Index));
    }

    private async Task<List<SelectListItem>> GetTeacherOptionsAsync() =>
        await dbContext.Teachers
            .OrderBy(t => t.FirstName).ThenBy(t => t.LastName)
            .Select(t => new SelectListItem(t.FirstName + " " + t.LastName, t.Id.ToString()))
            .ToListAsync();
}
