using System.ComponentModel.DataAnnotations;

namespace student_management_be_dotnet.ViewModels.Classes;

// Bound from the query string: /Classes?Filter.Search=...&Filter.TeacherId=1
public class ClassFilter
{
    [StringLength(100)]
    [Display(Name = "Tên hoặc mã lớp")]
    public string? Search { get; set; }

    [Display(Name = "Giáo viên")]
    public long? TeacherId { get; set; }
}
