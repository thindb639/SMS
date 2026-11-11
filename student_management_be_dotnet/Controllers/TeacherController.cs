using System.Data.Common;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using student_management_be_dotnet.Data;
using student_management_be_dotnet.Models;

namespace student_management_be_dotnet;

public class TeacherController(AppDbContext appdbContext) : Controller
{
    public async Task<IActionResult> Index()

    {
        var query = appdbContext.Teachers.AsQueryable();

        var teachers = await query.ToListAsync();

        return View(teachers);

    }
    public async Task<IActionResult> Creat()

    {

        return View();

    }

}


