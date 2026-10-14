namespace student_management_be_dotnet.Models;

using System.ComponentModel.DataAnnotations;
public class Class
{
    public long Id { get; set; }

    public required string Name { get; set; }

    public required string Code { get; set; }

    public long? TeacherId { get; set; }

    public Teacher? Teacher { get; set; }
}