using MedicalHub.Data;
using MedicalHub.Models;
using MedicalHub.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using System.Threading.Tasks;

namespace MedicalHub.Areas.Admin.Controllers;

[Area("Admin")]
public class SliderController(ApplicationDbContext db) : Controller
{
    public async Task<IActionResult> Index()
    {
        var sliders = await db.Sliders.OrderBy(p => p.Order).ToListAsync();
        return View(sliders);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SliderViewModel model)
    {
        if (ModelState.IsValid)
        {
            var slider = new Slider
            {
                Title = model.Title,
                LinkUrl = model.LinkUrl,
                IsActive = model.IsActive,
                Order = model.Order,
            };

            if (model.ImageUpload != null && model.ImageUpload.Length > 0)
            {
                using (var image = Image.Load(model.ImageUpload.OpenReadStream()))
                {
                    image.Mutate(x => x.Resize(new ResizeOptions
                    {
                        Mode = ResizeMode.Max,
                        Size = new Size(800, 600)
                    }));

                    using (var ms = new MemoryStream())
                    {
                        await image.SaveAsync(ms, new JpegEncoder { Quality = 75 });
                        slider.Image = ms.ToArray();
                    }
                }
            }

            await db.Sliders.AddAsync(slider);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        return View(model);
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var slider = await db.Sliders.FindAsync(id);

        if (slider == null)
        {
            return NotFound();
        }

        var model = new SliderViewModel
        {
            Id = slider.Id,
            Title = slider.Title,
            LinkUrl = slider.LinkUrl,
            IsActive = slider.IsActive,
            Order = slider.Order,
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(SliderViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var slider = await db.Sliders.FindAsync(model.Id);

        if(slider == null)
        {
            return NotFound();
        }

        slider.Title = model.Title;
        slider.LinkUrl = model.LinkUrl;
        slider.IsActive = model.IsActive;
        slider.Order = model.Order;

        if (model.ImageUpload != null && model.ImageUpload.Length > 0)
        {
            using (var image = Image.Load(model.ImageUpload.OpenReadStream()))
            {
                image.Mutate(x => x.Resize(new ResizeOptions
                {
                    Mode = ResizeMode.Max,
                    Size = new Size(800, 600)
                }));

                using (var ms = new MemoryStream())
                {
                    await image.SaveAsync(ms, new JpegEncoder { Quality = 75 });
                    slider.Image = ms.ToArray();
                }
            }
        }

        await db.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid id)
    {
        var slider = await db.Sliders.FindAsync(id);

        if (slider != null)
        {
            db.Sliders.Remove(slider);
            await db.SaveChangesAsync();
        }
        return RedirectToAction("Index");
    }
}
