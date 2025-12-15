using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalHub.Models;
public class Slider
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Title { get; set; }
    public byte[] Image { get; set; }
    public string? LinkUrl { get; set; }
    public bool IsActive { get; set; } = true;
    public int Order { get; set; }

    [NotMapped]
    public IFormFile? ImageUpload { get; set; }
}
