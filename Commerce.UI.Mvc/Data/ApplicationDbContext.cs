using Microsoft.EntityFrameworkCore;
using Commerce.Domain.Entities;
namespace Commerce.UI.Mvc.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Commerce.Domain.Entities.Category>? Category { get; set; }
}