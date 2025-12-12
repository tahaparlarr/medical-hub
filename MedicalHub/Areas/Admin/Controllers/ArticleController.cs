using Microsoft.AspNetCore.Mvc;

namespace MedicalHub.Areas.Admin.Controllers;

[Area("Admin")]
public class ArticleController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
