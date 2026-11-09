using System.ComponentModel.DataAnnotations;

namespace student_management_be_dotnet.Models;

public class Student
{
    public long Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty; //ko dc trống

    [Required]
    [MaxLength(10)]
    public string Code { get; set; } = string.Empty; //ko dc trống


    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty; //ko dc trống

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty; //ko dc trống

    [Required]
    [MaxLength(255)]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MaxLength(255)]
    public string? IdentificationNumber { get; set; }

    public long ClassId { get; set; }

    public DateTime DateOfBirth { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; }

    public Class? Class { get; set; }

    public string? Address { get; set; }

    public string? gender { get; set; }

     public long PhoneNumber { get; set; }
}
