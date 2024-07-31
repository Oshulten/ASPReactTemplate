using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class DefaultDataType(string? dataString)
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string? DataString { get; set; } = dataString;

        // An explicit parameterless constructor is required for database creation
        public DefaultDataType() : this(null) { }
    }
}