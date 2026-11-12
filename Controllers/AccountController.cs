using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Power7.Models;
using Power7.ViewModels;
using System.Security.Claims;

namespace Power7.Web.Controllers;

public class AccountController : Controller
{
    private readonly Power7Context _context;

    public AccountController(Power7Context context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Login() => User.Identity?.IsAuthenticated == true
        ? RedirectToAction("Index", "Catalog")
        : View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Email.ToLower() == model.Email.Trim().ToLower());

        if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
        {
            ModelState.AddModelError(string.Empty, "Email sau parolă incorectă.");
            return View(model);
        }

        await SignInUserAsync(user);
        return RedirectToAction("Index", "Catalog");
    }

    [HttpGet]
    public IActionResult Register() => User.Identity?.IsAuthenticated == true
        ? RedirectToAction("Index", "Catalog")
        : View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var emailNormalized = model.Email.Trim().ToLower();
        if (await _context.Users.AnyAsync(u => u.Email.ToLower() == emailNormalized))
        {
            ModelState.AddModelError("Email", "Există deja un cont cu acest email.");
            return View(model);
        }

        var user = new User
        {
            FullName = model.FullName.Trim(),
            Email = emailNormalized,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password),
            Role = "Customer"
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        await SignInUserAsync(user);
        return RedirectToAction("Index", "Catalog");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Catalog");
    }

    private async Task SignInUserAsync(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.FullName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(identity),
            new AuthenticationProperties { IsPersistent = true });
    }
}