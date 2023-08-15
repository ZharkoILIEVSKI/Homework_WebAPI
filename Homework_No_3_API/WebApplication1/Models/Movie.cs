using System.ComponentModel.DataAnnotations;
using WebApplication1.Models.Enum;

namespace WebApplication1.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
        
        [Required]
        public int Year { get; set; }

        [Required]
        public Genre Genre { get; set; }
        
    }
}
