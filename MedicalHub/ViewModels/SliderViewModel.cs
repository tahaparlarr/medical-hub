using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalHub.ViewModels;
public class SliderViewModel
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? LinkUrl { get; set; }
    public bool IsActive { get; set; } = true;
    public int Order { get; set; }
    public IFormFile? ImageUpload { get; set; }
}
