using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TME.Models;

namespace TME.ViewModel
{
  public class TeamInfoViewModel
  {
    public Team Team { get; set; }
    public List<Member> TeamMember { get; set; }
  }
}
