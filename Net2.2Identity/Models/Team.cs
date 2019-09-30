using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TME.Models
{
  public class Team : BaseClass
  {
    public Guid Id { get; set; }

    public string VentureName { get; set; }
    public string Industry { get; set; }

    public bool IsActive { get; set; }
    public string Status { get; set; }

  }
}
