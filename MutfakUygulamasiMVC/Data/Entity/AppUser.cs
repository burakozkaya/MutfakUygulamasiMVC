using Microsoft.AspNetCore.Identity;

namespace MutfakUygulamasiMVC.Data.Entity;

public class AppUser : IdentityUser<int>
{

    //Nav Property
    public List<Envanter> Envanterler { get; set; }
}