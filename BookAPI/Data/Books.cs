using System.ComponentModel.DataAnnotations;

namespace BookAPI.Data
{
    public class Books
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}