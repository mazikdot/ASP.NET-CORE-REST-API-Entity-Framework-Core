using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendASP.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }


        [Required]
        [Column(TypeName = "varchar(80)")]
        public string? CategoryName { get; set; }






    }
}
