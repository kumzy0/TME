using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TME.Models
{
  public class Member : BaseClass
  {
    public Guid Id { get; set; }

    public Guid TeamId { get; set; }
    public virtual Team Team { get; set; }

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

    public bool Student { get; set; }
    public bool Alumni { get; set; }
    public bool Other { get; set; }
    public string OtherField { get; set; }

    public bool IsActive { get; set; }
    public string Status { get; set; }
  }
}
