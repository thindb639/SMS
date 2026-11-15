using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using student_management_be_dotnet.Data;
using student_management_be_dotnet.Models;
using student_management_be_dotnet.ViewModels.Classes;

namespace student_management_be_dotnet.Controllers;

[Route("classes")]
public class ClassesController(AppDbContext dbContext) : Controller
{
    // GET /classes?Filter.Search=abc&Filter.TeacherId=1
    [HttpGet("")]
    public async Task<IActionResult> Index([FromQuery] ClassFilter filter)
    {
        var query = dbContext.Classes
            .Include(c => c.Teacher)
            .AsQueryable();

        if (!string.IsNullOrEmpty(filter.Search))
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

    // GET /classes/create
    [HttpGet("create")]
    public async Task<IActionResult> Create()
    {
        return View(new ClassCreateViewModel { TeacherOptions = await GetTeacherOptionsAsync() });
    }

    // POST /classes/create
    [HttpPost("create")]
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

    [HttpGet("{id:long}/edit")]
    public async Task<IActionResult> Edit(long id)
    {
        var entity = await dbContext.Classes.FindAsync(id);
        if (entity is null)
        {
            return NotFound();
        }

        return View(new ClassEditViewModel
        {
            Id = entity.Id,
            Code = entity.Code,
            Name = entity.Name,
            TeacherId = entity.TeacherId,
            TeacherOptions = await GetTeacherOptionsAsync(),
        });
    }

    [HttpPost("{id:long}/edit")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, ClassEditViewModel model)
    {
        var entity = await dbContext.Classes.FindAsync(id);
        if (entity is null)
        {
            return NotFound();
        }

        var code = model.Code.Trim();

        if (await dbContext.Classes.AnyAsync(c => c.Code == code && c.Id != id))
        {
            ModelState.AddModelError(nameof(model.Code), "Mã lớp đã tồn tại");
        }

        if (model.TeacherId is not null && !await dbContext.Teachers.AnyAsync(t => t.Id == model.TeacherId))
        {
            ModelState.AddModelError(nameof(model.TeacherId), "Giáo viên không tồn tại");
        }

        if (!ModelState.IsValid)
        {
            model.Id = id;
            model.TeacherOptions = await GetTeacherOptionsAsync();
            return View(model);
        }

        entity.Code = code;
        entity.Name = model.Name.Trim();
        entity.TeacherId = model.TeacherId;
        await dbContext.SaveChangesAsync();

        TempData["Success"] = "Đã cập nhật lớp";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost("{id:long}/delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(long id)
    {
        var entity = await dbContext.Classes.FindAsync(id);
        if (entity is null)
        {
            return NotFound();
        }

        // Students.ClassId is a cascading FK: deleting a class with students would delete them too
        if (await dbContext.Students.AnyAsync(s => s.ClassId == id))
        {
            TempData["Error"] = $"Không thể xóa lớp {entity.Code} vì lớp vẫn còn học sinh";
            return RedirectToAction(nameof(Index));
        }

        dbContext.Classes.Remove(entity);
        await dbContext.SaveChangesAsync();

        TempData["Success"] = "Đã xóa lớp";
        return RedirectToAction(nameof(Index));
    }

    private async Task<List<SelectListItem>> GetTeacherOptionsAsync() =>
        await dbContext.Teachers
            .OrderBy(t => t.FirstName).ThenBy(t => t.LastName)
            .Select(t => new SelectListItem(t.FirstName + " " + t.LastName, t.Id.ToString()))
            .ToListAsync();
}
