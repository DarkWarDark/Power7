using Power7.Models;
using System.Linq;

namespace Power7.Models
{
    public static class DbInitializer
    {
        public static void Initialize(Power7Context context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // 1. Seed Produse & Categorii
            if (!context.Products.Any())
            {
                var categEnergizante = new Category { Name = "Energy Drinks" };
                var categPreWorkout = new Category { Name = "Pre-Workout" };
                var categCafea = new Category { Name = "Coffee" };
                var categSucuri = new Category { Name = "Natural Refreshments" };

                var categories = new Category[] { categEnergizante, categPreWorkout, categCafea, categSucuri };
                context.Categories.AddRange(categories);
                context.SaveChanges();

                var products = new Product[]
                {
                    new Product { Name = "Monster Energy Green", Description = "Classic energy drink 500ml", Price = 7.50m, Stock = 100, Image_url = "/images/monster_green.jpg", Category = categEnergizante },
                    new Product { Name = "Monster Ultra White", Description = "Sugar-free, citrus flavor 500ml", Price = 7.50m, Stock = 80, Image_url = "/images/monster_white.jpg", Category = categEnergizante },
                    new Product { Name = "Red Bull Original", Description = "Premium energy drink 250ml", Price = 6.00m, Stock = 150, Image_url = "/images/redbull.jpg", Category = categEnergizante },
                    new Product { Name = "Red Bull Sugarfree", Description = "Sugar-free premium energy drink 250ml", Price = 6.00m, Stock = 120, Image_url = "/images/redbull_sf.jpg", Category = categEnergizante },
                    new Product { Name = "Hell Classic", Description = "Classic apple-flavored energy drink 250ml", Price = 3.50m, Stock = 200, Image_url = "/images/hell.jpg", Category = categEnergizante },
                    new Product { Name = "Hell Apple", Description = "Apple-flavored energy drink 250ml", Price = 3.50m, Stock = 90, Image_url = "/images/hell_apple.jpg", Category = categEnergizante },
                    new Product { Name = "Rockstar Original", Description = "Rockstar energy drink 500ml", Price = 5.50m, Stock = 60, Image_url = "/images/rockstar.jpg", Category = categEnergizante },
                    new Product { Name = "Rockstar Guava", Description = "Guava-flavored energy drink 500ml", Price = 5.50m, Stock = 50, Image_url = "/images/rockstar_guava.jpg", Category = categEnergizante },

                    new Product { Name = "C4 Original 30 servings", Description = "Explosive cherry-flavored pre-workout", Price = 120.00m, Stock = 30, Image_url = "/images/c4.jpg", Category = categPreWorkout },
                    new Product { Name = "C4 Ripped 30 servings", Description = "Pre-workout with cutting effect", Price = 140.00m, Stock = 25, Image_url = "/images/c4_ripped.jpg", Category = categPreWorkout },
                    new Product { Name = "N.O.-Xplode 600g", Description = "Legendary BSN pre-workout", Price = 160.00m, Stock = 20, Image_url = "/images/noxplode.jpg", Category = categPreWorkout },
                    new Product { Name = "Gold Standard Pre-Workout", Description = "Optimum Nutrition, 330g", Price = 135.00m, Stock = 40, Image_url = "/images/gold_pre.jpg", Category = categPreWorkout },
                    new Product { Name = "ABE Applied Nutrition", Description = "All Black Everything 315g", Price = 145.00m, Stock = 15, Image_url = "/images/abe.jpg", Category = categPreWorkout },
                    new Product { Name = "Ghost Legend Pre-Workout", Description = "Sour Patch Kids flavor", Price = 180.00m, Stock = 10, Image_url = "/images/ghost.jpg", Category = categPreWorkout },
                    new Product { Name = "Cellucor C4 Ultimate", Description = "Extreme pre-workout formula", Price = 190.00m, Stock = 12, Image_url = "/images/c4_ultimate.jpg", Category = categPreWorkout },

                    new Product { Name = "Lavazza Qualita Oro 1kg", Description = "Premium whole bean coffee", Price = 85.00m, Stock = 45, Image_url = "/images/lavazza_oro.jpg", Category = categCafea },
                    new Product { Name = "Lavazza Crema e Gusto 250g", Description = "Intense ground coffee", Price = 20.00m, Stock = 100, Image_url = "/images/lavazza_crema.jpg", Category = categCafea },
                    new Product { Name = "Jacobs Krönung 500g", Description = "Medium roast ground coffee", Price = 25.00m, Stock = 80, Image_url = "/images/jacobs.jpg", Category = categCafea },
                    new Product { Name = "Tchibo Espresso Sicilia 1kg", Description = "Southern Italian style whole bean coffee", Price = 75.00m, Stock = 30, Image_url = "/images/tchibo.jpg", Category = categCafea },
                    new Product { Name = "Illy Classico 250g", Description = "100% Arabica ground coffee", Price = 45.00m, Stock = 25, Image_url = "/images/illy.jpg", Category = categCafea },
                    new Product { Name = "Starbucks Pike Place 200g", Description = "Medium roast whole bean coffee", Price = 30.00m, Stock = 40, Image_url = "/images/starbucks.jpg", Category = categCafea },
                    new Product { Name = "Nescafe Gold 200g", Description = "Premium instant coffee", Price = 35.00m, Stock = 60, Image_url = "/images/nescafe.jpg", Category = categCafea },
                    new Product { Name = "Davidoff Rich Aroma 250g", Description = "Luxury ground coffee", Price = 28.00m, Stock = 35, Image_url = "/images/davidoff.jpg", Category = categCafea },

                    new Product { Name = "Santal Orange 1L", Description = "100% orange juice", Price = 8.50m, Stock = 150, Image_url = "/images/santal_portocale.jpg", Category = categSucuri },
                    new Product { Name = "Santal Apple 1L", Description = "100% green apple juice", Price = 7.50m, Stock = 120, Image_url = "/images/santal_mere.jpg", Category = categSucuri },
                    new Product { Name = "Cappy Pulpy Peach 1.5L", Description = "Refreshing fruit drink with pulp", Price = 6.50m, Stock = 200, Image_url = "/images/cappy.jpg", Category = categSucuri },
                    new Product { Name = "Tymbark Multivitamin 2L", Description = "Multivitamin nectar", Price = 9.00m, Stock = 90, Image_url = "/images/tymbark_multi.jpg", Category = categSucuri },
                    new Product { Name = "Granini Orange 1.5L", Description = "Orange juice with pulp", Price = 11.00m, Stock = 50, Image_url = "/images/granini.jpg", Category = categSucuri },
                    new Product { Name = "Tymbark Sour Cherry 2L", Description = "Sour cherry and apple nectar", Price = 9.00m, Stock = 70, Image_url = "/images/tymbark_visine.jpg", Category = categSucuri },
                    new Product { Name = "Pfanner Apple 2L", Description = "Unfiltered apple juice", Price = 12.50m, Stock = 40, Image_url = "/images/pfanner.jpg", Category = categSucuri }
                };

                context.Products.AddRange(products);
                context.SaveChanges();
            }

            // 2. Seed Utilizatori Demo pentru Login (A4)
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User
                    {
                        FullName = "Claudiu Mihai",
                        Email = "student@power7.ro",
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("Power7User123!"),
                        Role = "Customer"
                    },
                    new User
                    {
                        FullName = "Power7 Admin",
                        Email = "admin@power7.ro",
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("Power7Admin123!"),
                        Role = "Admin"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}