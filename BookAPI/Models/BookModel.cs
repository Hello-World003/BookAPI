using System.ComponentModel.DataAnnotations;

namespace BookAPI.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Please Add title property")]
        public string Title { get; set; }
        public string Description { get; set; }
        
        // n-layer, clean-attr, ...
    }
}