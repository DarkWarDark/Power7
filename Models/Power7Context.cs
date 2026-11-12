using Microsoft.EntityFrameworkCore;

namespace Power7.Models
{
    public class Power7Context : DbContext
    {
        public Power7Context(DbContextOptions<Power7Context> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart_Item> Cart_Items { get; set; }

        public DbSet<User> Users { get; set; }
    }
}