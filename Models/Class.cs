using System.ComponentModel.DataAnnotations;

namespace student_management_be_dotnet.Models;

class Class
{
    [Required, MaxLength(100)]
    public string Name { get; set; }

    [Required, MaxLength(100)]
    public string ClassId { get; set; }

    [Required, MaxLength(50)]
    public string TeacherId { get; set; }

    public ICollection<Student> Students {get;set;}

}