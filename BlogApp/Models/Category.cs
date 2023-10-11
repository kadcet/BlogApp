using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [StringLength(12)]
        [Required]

        public string Name { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
