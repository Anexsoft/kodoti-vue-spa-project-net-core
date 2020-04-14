using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Model.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public List<ApplicationUserRole> UserRoles { get; set; }
    }
}
