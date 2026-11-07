namespace student_management_be_dotnet.ViewModels.Student;

public class StudentCreateViewModel
{
    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty; //ko đc trống

    public long ClassId { get; set; }

    
}

// [Require(ErorMassage = "Vui lòng nhập tên sinh viên")]



