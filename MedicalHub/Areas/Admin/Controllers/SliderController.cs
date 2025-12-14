using MedicalHub.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicalHub.Areas.Admin.Controllers;

[Area("Admin")]
public class SliderController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    //public Task<IActionResult> Create(Slider model)
    //{
    //    if (model == null)
    //    {
    //        return BadRequest();
    //    }
    //    else
    //    {
    //        Id = model.Id;

    //    }
    //}
}
