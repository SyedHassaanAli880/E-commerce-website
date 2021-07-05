using Microsoft.AspNetCore.Identity;
using BethinyShop.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethinyShop.ViewModel
{
    public class UserRoleViewModel
    {
        public UserRoleViewModel()
        {
            Users = new List<IdentityUser>();
        }

        public string UserId { get; set; }

        public string RoleId { get; set; }

        public List<IdentityUser> Users { get; set; }
        
    }
}
