using MedicalHub.Data;
using Microsoft.AspNetCore.Mvc;

namespace MedicalHub.Controllers;

public class MediaController(ApplicationDbContext db) : Controller
{
    [ResponseCache(Duration = 1200)]
    public async Task<IActionResult> GetSliderImage(Guid id)
    {
        var item = await db.Sliders.FindAsync(id);
        if (item == null || item.Image == null)
        {
            return NotFound();
        }

        return File(item.Image, "image/jpeg");
    }
}
