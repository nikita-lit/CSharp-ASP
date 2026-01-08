using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PeodeApp.Models;

namespace PeodeApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<Kylaline> Kylalined { get; set; }
        public DbSet<Pyha> Pyhad { get; set; }
    }
}
