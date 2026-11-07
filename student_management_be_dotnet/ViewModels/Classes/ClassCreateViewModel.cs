using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace student_management_be_dotnet.ViewModels.Classes;

public class ClassCreateViewModel
{
    [Required(ErrorMessage = "Vui lòng nhập mã lớp")]
    [StringLength(20, ErrorMessage = "Mã lớp tối đa {1} ký tự")]
    [Display(Name = "Mã lớp")]
    public string Code { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng nhập tên lớp")]
    [StringLength(100, ErrorMessage = "Tên lớp tối đa {1} ký tự")]
    [Display(Name = "Tên lớp")]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "Giáo viên chủ nhiệm")]
    public long? TeacherId { get; set; }

    // Display-only data for the view, not posted back by the form
    public IEnumerable<SelectListItem> TeacherOptions { get; set; } = [];
}
