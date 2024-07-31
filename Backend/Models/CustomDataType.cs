using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class CustomDataType(string? dataString)
    {
        public Guid Id { get; init; }
        public string? DataString { get; set; } = dataString;
    }
}