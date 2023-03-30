using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InternetAssignment.Models
{
    public class AppDataContext : IdentityDbContext<AppUser>
    {
        public AppDataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Product> Products { get; set; }        
       


    }
}
