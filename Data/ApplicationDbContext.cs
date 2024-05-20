using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpravaUdalosti.Models;

namespace SpravaUdalosti.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<SpravaUdalosti.Models.Event> Event { get; set; } = default!;
        public DbSet<SpravaUdalosti.Models.Interprets> Interprets { get; set; } = default!;
    }
}
