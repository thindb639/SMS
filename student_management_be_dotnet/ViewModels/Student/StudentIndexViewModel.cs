using student_management_be_dotnet.Models;
using StudentModel = student_management_be_dotnet.Models.Student;
namespace student_management_be_dotnet.ViewModels.Student
{
    public class StudentIndexViewModel()
    {
        public StudentFilter studentFilter { get; set; } = new();

        public List<StudentModel> Students { get; set; } = [];
    }
}