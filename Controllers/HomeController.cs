using Microsoft.AspNetCore.Mvc;

namespace student_management_be_dotnet.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
