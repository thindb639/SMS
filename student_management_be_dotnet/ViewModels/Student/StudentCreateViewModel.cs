using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace student_management_be_dotnet.ViewModels.Student;

public class StudentCreateViewModel
{
    [Required(ErrorMessage = "Vui lòng nhập tên ")]
    [StringLength(100, ErrorMessage = "Tên tối đa {1} ký tự")]
    [Display(Name = "Tên")]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;

    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public long PhoneNumber { get; set; }

    public string? IdentificationNumber { get; set; }

    public string? Address { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập tên email")]
    [StringLength(100, ErrorMessage = "Email tối đa {1} ký tự")]
    [Display(Name = "Email")]
    public string Email { get; set; } = string.Empty; //ko đc trống

    [Required]
    public long ClassId { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập mã lớp")]
    [StringLength(20, ErrorMessage = "Mã lớp tối đa {1} ký tự")]
    [Display(Name = "Mã lớp")]
    public string Code { get; set; } = string.Empty;

    [Required]
    [DisplayFormat(DataFormatString = "yyy-mm-dd}", ApplyFormatInEditMode = true)]
    public DateOnly DateOfBirth { get; set; }

    public string? gender { get; set; }

}

// [Require(ErorMassage = "Vui lòng nhập tên sinh viên")]



