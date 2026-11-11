using Power7.Models;
using System.Linq;

namespace Power7.Web.Models
{
    public static class DbInitializer
    {
        public static void Initialize(Power7Context context)
        {
            context.Database.EnsureCreated();

            if (context.Products.Any())
            {
                return;
            }

            var categEnergizante = new Category { Name = "Energizante" };
            var categPreWorkout = new Category { Name = "Pre-Workout" };
            var categCafea = new Category { Name = "Cafea" };
            var categSucuri = new Category { Name = "Sucuri Naturale" };

            var categories = new Category[] { categEnergizante, categPreWorkout, categCafea, categSucuri };
            context.Categories.AddRange(categories);
            context.SaveChanges();

            var products = new Product[]
            {

                new Product { Name = "Monster Energy Green", Description = "Băutură energizantă clasică 500ml", Price = 7.50m, Stock = 100, Image_url = "/images/monster_green.jpg", Category = categEnergizante },
                new Product { Name = "Monster Ultra White", Description = "Fără zahăr, aromă de citrice 500ml", Price = 7.50m, Stock = 80, Image_url = "/images/monster_white.jpg", Category = categEnergizante },
                new Product { Name = "Red Bull Original", Description = "Energizant premium 250ml", Price = 6.00m, Stock = 150, Image_url = "/images/redbull.jpg", Category = categEnergizante },
                new Product { Name = "Red Bull Sugarfree", Description = "Energizant premium fără zahăr 250ml", Price = 6.00m, Stock = 120, Image_url = "/images/redbull_sf.jpg", Category = categEnergizante },
                new Product { Name = "Hell Classic", Description = "Energizant clasic cu mere 250ml", Price = 3.50m, Stock = 200, Image_url = "/images/hell.jpg", Category = categEnergizante },
                new Product { Name = "Hell Apple", Description = "Energizant aromă mere 250ml", Price = 3.50m, Stock = 90, Image_url = "/images/hell_apple.jpg", Category = categEnergizante },
                new Product { Name = "Rockstar Original", Description = "Energizant Rockstar 500ml", Price = 5.50m, Stock = 60, Image_url = "/images/rockstar.jpg", Category = categEnergizante },
                new Product { Name = "Rockstar Guava", Description = "Energizant cu aromă de guava 500ml", Price = 5.50m, Stock = 50, Image_url = "/images/rockstar_guava.jpg", Category = categEnergizante },

                new Product { Name = "C4 Original 30 serviri", Description = "Pre-workout exploziv aromă cireșe", Price = 120.00m, Stock = 30, Image_url = "/images/c4.jpg", Category = categPreWorkout },
                new Product { Name = "C4 Ripped 30 serviri", Description = "Pre-workout cu efect de definire", Price = 140.00m, Stock = 25, Image_url = "/images/c4_ripped.jpg", Category = categPreWorkout },
                new Product { Name = "N.O.-Xplode 600g", Description = "Pre-workout legendar BSN", Price = 160.00m, Stock = 20, Image_url = "/images/noxplode.jpg", Category = categPreWorkout },
                new Product { Name = "Gold Standard Pre-Workout", Description = "Optimum Nutrition, 330g", Price = 135.00m, Stock = 40, Image_url = "/images/gold_pre.jpg", Category = categPreWorkout },
                new Product { Name = "ABE Applied Nutrition", Description = "All Black Everything 315g", Price = 145.00m, Stock = 15, Image_url = "/images/abe.jpg", Category = categPreWorkout },
                new Product { Name = "Ghost Legend Pre-Workout", Description = "Aromă Sour Patch Kids", Price = 180.00m, Stock = 10, Image_url = "/images/ghost.jpg", Category = categPreWorkout },
                new Product { Name = "Cellucor C4 Ultimate", Description = "Formulă extremă pre-antrenament", Price = 190.00m, Stock = 12, Image_url = "/images/c4_ultimate.jpg", Category = categPreWorkout },

                new Product { Name = "Lavazza Qualita Oro 1kg", Description = "Cafea boabe premium", Price = 85.00m, Stock = 45, Image_url = "/images/lavazza_oro.jpg", Category = categCafea },
                new Product { Name = "Lavazza Crema e Gusto 250g", Description = "Cafea măcinată intensă", Price = 20.00m, Stock = 100, Image_url = "/images/lavazza_crema.jpg", Category = categCafea },
                new Product { Name = "Jacobs Krönung 500g", Description = "Cafea măcinată prăjire medie", Price = 25.00m, Stock = 80, Image_url = "/images/jacobs.jpg", Category = categCafea },
                new Product { Name = "Tchibo Espresso Sicilia 1kg", Description = "Cafea boabe stil sud-italian", Price = 75.00m, Stock = 30, Image_url = "/images/tchibo.jpg", Category = categCafea },
                new Product { Name = "Illy Classico 250g", Description = "Cafea măcinată 100% Arabica", Price = 45.00m, Stock = 25, Image_url = "/images/illy.jpg", Category = categCafea },
                new Product { Name = "Starbucks Pike Place 200g", Description = "Cafea boabe prăjire medie", Price = 30.00m, Stock = 40, Image_url = "/images/starbucks.jpg", Category = categCafea },
                new Product { Name = "Nescafe Gold 200g", Description = "Cafea solubilă premium", Price = 35.00m, Stock = 60, Image_url = "/images/nescafe.jpg", Category = categCafea },
                new Product { Name = "Davidoff Rich Aroma 250g", Description = "Cafea măcinată de lux", Price = 28.00m, Stock = 35, Image_url = "/images/davidoff.jpg", Category = categCafea },

                new Product { Name = "Santal Portocale 1L", Description = "Suc 100% portocale", Price = 8.50m, Stock = 150, Image_url = "/images/santal_portocale.jpg", Category = categSucuri },
                new Product { Name = "Santal Mere 1L", Description = "Suc 100% mere verzi", Price = 7.50m, Stock = 120, Image_url = "/images/santal_mere.jpg", Category = categSucuri },
                new Product { Name = "Cappy Pulpy Piersici 1.5L", Description = "Băutură răcoritoare cu pulpă", Price = 6.50m, Stock = 200, Image_url = "/images/cappy.jpg", Category = categSucuri },
                new Product { Name = "Tymbark Multivitamine 2L", Description = "Nectar multivitamine", Price = 9.00m, Stock = 90, Image_url = "/images/tymbark_multi.jpg", Category = categSucuri },
                new Product { Name = "Granini Portocale 1.5L", Description = "Suc cu pulpă de portocale", Price = 11.00m, Stock = 50, Image_url = "/images/granini.jpg", Category = categSucuri },
                new Product { Name = "Tymbark Vișine 2L", Description = "Nectar de vișine și mere", Price = 9.00m, Stock = 70, Image_url = "/images/tymbark_visine.jpg", Category = categSucuri },
                new Product { Name = "Pfanner Mere 2L", Description = "Suc de mere nefiltrat", Price = 12.50m, Stock = 40, Image_url = "/images/pfanner.jpg", Category = categSucuri }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}