using Microsoft.AspNetCore.Mvc;
using Power7.Models;
using System.Diagnostics;

namespace Power7.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var facts = new[]
            {
        new { Category = "Caffeine & Focus", Fact = "Caffeine blocks adenosine receptors in the brain within 15–45 minutes, reaching peak blood concentration at around 45 minutes." },
        new { Category = "Smart Synergy", Fact = "Pairing L-Theanine with caffeine reduces jitters and improves sustained attention compared to taking caffeine alone." },
        new { Category = "Pre-Workout Science", Fact = "L-Citrulline boosts nitric oxide levels more effectively than L-Arginine because it bypasses first-pass liver breakdown." },
        new { Category = "Strength & Power", Fact = "Creatine monohydrate saturates muscle phosphocreatine stores, speeding up ATP regeneration during explosive sets." },
        new { Category = "Natural Endurance", Fact = "Cold-pressed beetroot juice is rich in dietary nitrates, lowering the oxygen cost of exercise and improving stamina." },
        new { Category = "Coffee Chemistry", Fact = "Light and medium coffee roasts preserve more chlorogenic antioxidants than dark roasts while keeping virtually the same caffeine content." },
        new { Category = "Hydration", Fact = "Even a 2% drop in body hydration can measurably reduce focus, reaction time, and physical endurance." },
        new { Category = "Vitamin Retention", Fact = "Cold-pressed natural juices protect heat-sensitive nutrients like Vitamin C that degrade during high-temperature pasteurization." }
    };

            int indexOfTheDay = DateTime.Today.DayOfYear % facts.Length;
            ViewBag.DailyFactCategory = facts[indexOfTheDay].Category;
            ViewBag.DailyFactText = facts[indexOfTheDay].Fact;
            ViewBag.AllFactsJson = System.Text.Json.JsonSerializer.Serialize(facts);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
