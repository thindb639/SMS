using System.ComponentModel.DataAnnotations;

namespace student_management_be_dotnet.Models
{

    public class Teacher
    {
        public long Id { get; set; }
        public ICollection<Class>? Class { get; }
        public string GetBirthDay()
        {
            return this.DateOfBirth?.ToString("dd/MM/yyyy") ?? string.Empty;
        }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]

        public string LastName { get; set; } = string.Empty;

        public DateOnly? DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string Code { get; set; } = "";
        public string Phone { get; set; } = "";
        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; } = "";
        public string Subject { get; set; } = "";
        public string Degree { get; set; } = "";
        public DateOnly? JoinDate { get; set; }
        public string Address { get; set; } = "";

    }

    public enum Gender : byte
    {
        Male = 1,
        Female = 2,
        Unknown = 3
    }
}