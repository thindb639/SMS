namespace student_management_be_dotnet.ViewModels.Student;

public class StudentCreateViewModel
{
    public string LastName { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public long PhoneNumber { get; set; }

    public string? IdentificationNumber { get; set; }

    public string? Address { get; set; }
    public string Email { get; set; } = string.Empty; //ko đc trống

    public long ClassId { get; set; }

    public string Code { get; set; } = string.Empty;

     public DateTime DateOfBirth { get; set; }

    public string? gender { get; set; }
}

// [Require(ErorMassage = "Vui lòng nhập tên sinh viên")]



