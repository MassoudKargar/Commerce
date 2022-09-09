using Commerce.Domain.ApplicationService;

using Microsoft.AspNetCore.Mvc;

namespace Commerce.UI.Mvc.Areas.Category.Controllers;

[Area("Category")]
[Authorize]
public class Category : Controller
{
    public Category(CategoryService categoryService)
    {
        CategoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
    }

    private CategoryService CategoryService { get; }
    [HttpGet]
    public IActionResult AddAsync()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync(Domain.Entities.Category category, CancellationToken token)
    {
        if (string.IsNullOrWhiteSpace(category.Name))
        {
            return View(category);
        }
        if (!token.IsCancellationRequested)
        {
            await CategoryService.AddCategoryAsync(category.Name);
            return View();
        }
        return View(category);
    }
}
