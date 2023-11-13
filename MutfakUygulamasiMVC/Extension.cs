using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using MutfakUygulamasiMVC.Data.Context;

namespace MutfakUygulamasiMVC;

public static class Extension
{
    public static void AddIndetityConfiguration<TUser, TRole>(this IServiceCollection service) 
        where TUser : IdentityUser<int>
        where TRole : IdentityRole<int>
    {
        service.AddIdentity<TUser, TRole>(option =>
        {
            option.User.RequireUniqueEmail = true;
        }).AddEntityFrameworkStores<ApplicationDbContext>();
    }
}