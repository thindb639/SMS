using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using student_management_be_dotnet.Data;

namespace student_management_be_dotnet.Controllers;

public class ClassesController(AppDbContext dbContext) : Controller
{
    public async Task<IActionResult> Index()
    {
        var classes = await dbContext.Classes
            .AsQueryable()
            .ToListAsync();

        return View(classes);
    }
}
