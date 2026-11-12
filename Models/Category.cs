using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Power7.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The name of the product is mandatory")]
        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}