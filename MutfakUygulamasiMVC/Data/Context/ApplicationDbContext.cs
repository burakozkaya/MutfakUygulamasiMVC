using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MutfakUygulamasiMVC.Data.Entity;

namespace MutfakUygulamasiMVC.Data.Context;

public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole,int>
{
    public DbSet<Envanter> Envanterler { get; set; }
    public DbSet<Urun> Urunler { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
        
    }
}