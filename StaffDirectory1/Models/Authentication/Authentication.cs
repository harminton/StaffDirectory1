using Microsoft.AspNetCore.Identity;

namespace StaffDirectory1.Models.Authentication
{
    public class Authentication
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;

    }
}
