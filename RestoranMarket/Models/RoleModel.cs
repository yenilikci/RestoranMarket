using Microsoft.AspNetCore.Identity;
using RestoranMarket.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestoranMarket.Models
{
    public class RoleDetails
    {
        public IdentityRole Role { get; set; }
        //Rol içerisindeki kullanıcılar;
        public IEnumerable<ApplicationUser> Members { get; set; }
        //Rol içerisinde olmayan kullanıcılar;
        public IEnumerable<ApplicationUser> NonMembers { get; set; }
    }

    public class RoleEditModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string[] IdsToAdd{ get; set; }
        public string[] IdsToDelete { get; set; }

    }
}
