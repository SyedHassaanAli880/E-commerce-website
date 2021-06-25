using Microsoft.AspNetCore.Identity;
using System;

namespace BethinyShop.Auth
{
    public class ApplicationUser:IdentityUser
    {
        public DateTime Birthdate { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
