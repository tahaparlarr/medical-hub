using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MedicalHub.Models;
using MedicalHub.Data;
using Microsoft.EntityFrameworkCore;

namespace MedicalHub.Controllers;

public class HomeController(ApplicationDbContext db) : Controller
{
    public async Task<IActionResult> Index()
    {
        var sliders = await db.Sliders.Where(p => p.IsActive).OrderBy(p=>p.Order).ToListAsync();

        return View(sliders);
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
