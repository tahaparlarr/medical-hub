using MedicalHub.Data;
using Microsoft.AspNetCore.Mvc;

namespace MedicalHub.Areas.Admin.Controllers;

[Area("Admin")]
public class DashboardController(ApplicationDbContext db) : Controller
{
    public IActionResult Index()
    {
        ViewBag.SliderCount = db.Sliders.Where(p => p.IsActive).Count();

        return View();
    }
}
