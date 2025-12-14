using MedicalHub.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalHub.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Slider> Sliders { get; set; }
}
