using System.ComponentModel.DataAnnotations;

namespace Power7.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Numele produsului este obligatoriu")]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        [Range(0.01, 10000.00, ErrorMessage = "Pretul trebuie sa fie mai mare ca 0")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, 10000, ErrorMessage = "Stocul nu poate fi negativ")]
        public int Stock { get; set; }

        public string Image_url { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
