using System.ComponentModel.DataAnnotations;

namespace student_management_be_dotnet.Models;

public class Teacher
{
    public long Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set;} = string.Empty;

    public DateOnly? DateOfBirth {get; set;} 

    public Gender Gender {get;set;}

    public ICollection<Class>? Class {get;}
}

public enum Gender : byte
{
    Male = 1,
    Female = 2,
    Unknown = 3
}