using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Power7.Models;
using Power7.ViewModels;

namespace Power7.Web.Controllers;

public class CatalogController : Controller
{
    private readonly Power7Context _context;
    private const int PageSize = 12;

    public CatalogController(Power7Context context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(int? categoryId, string? search, string? sort, int page = 1)
    {
        if (page < 1) page = 1;

        var query = _context.Products
            .Include(p => p.Category)
            .AsQueryable();

        if (categoryId.HasValue)
        {
            query = query.Where(p => p.CategoryId == categoryId.Value);
        }

        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.Trim().ToLower();
            query = query.Where(p => p.Name.ToLower().Contains(term) || p.Description.ToLower().Contains(term));
        }

        query = sort switch
        {
            "price_asc" => query.OrderBy(p => (double)p.Price),
            "price_desc" => query.OrderByDescending(p => (double)p.Price),
            _ => query.OrderBy(p => p.Id)
        };

        var totalItems = await query.CountAsync();
        var totalPages = Math.Max(1, (int)Math.Ceiling(totalItems / (double)PageSize));
        if (page > totalPages) page = totalPages;

        var products = await query
            .Skip((page - 1) * PageSize)
            .Take(PageSize)
            .ToListAsync();

        var vm = new CatalogViewModel
        {
            Products = products,
            Categories = await _context.Categories.ToListAsync(),
            SelectedCategoryId = categoryId,
            SearchQuery = search,
            SortBy = sort,
            CurrentPage = page,
            TotalPages = totalPages,
            TotalItems = totalItems
        };

        return View(vm);
    }
}