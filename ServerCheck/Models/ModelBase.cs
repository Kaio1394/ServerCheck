using System.ComponentModel.DataAnnotations;

namespace ServerCheck.Models
{
    public class ModelBase
    {
        [Key]
        [Required]
        public string? Uuid { get; set; } = Guid.NewGuid().ToString();
    }
}