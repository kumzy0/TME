using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TME.Models
{
  public class Mentor : BaseClass
  {
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string OtherName { get; set; }
    public string NickName { get; set; }

    public string Email { get; set; }
    public string PhoneNumberMobile { get; set; }
    public string PhoneNumberWork { get; set; }

    public string Address { get; set; }
    public string City { get; set; }
    public string Province { get; set; }
    public string Country { get; set; }

    public string Industry { get; set; }
    public string Expertise { get; set; }
    public string Interest { get; set; }
    public string Profile { get; set; }

    public bool IsActive { get; set; }
    public string Status { get; set; }

    public string ImageUrl { get; set; }
    public string ProfileUrl { get; set; }

    public string LinkedIn { get; set; }
  }
}
