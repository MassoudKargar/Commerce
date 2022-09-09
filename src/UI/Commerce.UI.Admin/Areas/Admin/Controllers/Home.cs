using Microsoft.AspNetCore.Mvc;

namespace Commerce.UI.Admin.Areas.Admin.Controllers;

[Area("Admin")]
public class Home : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
