using System.ComponentModel.DataAnnotations;

namespace BookAPI.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublishedYear { get; set; }
    
    }
}
