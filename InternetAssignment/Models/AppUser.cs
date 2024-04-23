using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace InternetAssignment.Models
{
    public class AppUser : IdentityUser
    {        
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
