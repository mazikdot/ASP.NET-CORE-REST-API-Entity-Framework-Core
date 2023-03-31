using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendASP.Models
{
    public class Percel
    {
        [Key]
        public int id {  get; set; }

        [Column(TypeName = "varchar(50)")] 
        public string? PercelName { get; set; }

        public int CategoryId { get; set; }


       //[Column(TypeName = "varchar(50)")]
       //public string? category { get; set; }

        //[Column(TypeName = "varchar(80)")]
       // public string? category2 { get; set; }

        //public DateTime timerequest { get; set; } = DateTime.Now;

    }
}
