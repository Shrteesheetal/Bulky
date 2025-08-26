using System.ComponentModel.DataAnnotations;

namespace BulkyWebRazor_Temp.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(30)]//validation is added
        public string? Name { get; set; }
        [Range(1, 100, ErrorMessage = "Display Order Must be between 1-100")]
        public string? DisplayOrder { get; set; }
    }
}
