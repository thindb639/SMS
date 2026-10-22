using Microsoft.AspNetCore.Mvc.Rendering;
using student_management_be_dotnet.Models;

namespace student_management_be_dotnet.ViewModels.Classes;

public class ClassIndexViewModel
{
    public ClassFilter Filter { get; set; } = new();

    public List<Class> Classes { get; set; } = [];

    // Display-only data for the filter form
    public IEnumerable<SelectListItem> TeacherOptions { get; set; } = [];
}
