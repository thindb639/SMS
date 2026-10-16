using System.ComponentModel.DataAnnotations;

namespace student_management_be_dotnet.Models;

class Student
{
    public long Id { set; get; }

    [Required, MaxLength(100)]
    public string LastName { get; set; }

    [Required, MaxLength(100)]
    public string FirstName { get; set; }

    [Required, MaxLength(100)]
    public long ClassId { get; set;}
    
  
    [AllowedValues(0, 1, 3, ErrorMessage = "Nu 0, Nam 1, Khac 3 ")]
    public int Gender{ get; set;}

    [Phone(ErrorMessage = "Số điện thoại không đúng định dạng.")]
   public string Phone{ get; set;}

    [Required, MaxLength(100)]
   public string Address{ get; set; }

   public Class MyClass {get;set;}
}