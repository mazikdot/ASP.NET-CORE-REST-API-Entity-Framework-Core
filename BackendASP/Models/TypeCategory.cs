using System.ComponentModel.DataAnnotations;

namespace BackendASP.Models
{
    public class TypeCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }    
    }
}
