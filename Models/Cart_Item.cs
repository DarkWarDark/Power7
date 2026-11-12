using System.ComponentModel.DataAnnotations;

namespace Power7.Models
{
    public class Cart_Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "The quantity must be at least 1")]
        public int Quantity { get; set; }
    }
}