using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Net2._2Identity.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
      public string FullName { get; set; }
    public string Status { get; set; }
    public string UserRole { get; set; }

    public bool? IsEnabled { get; set; }

    }
}
