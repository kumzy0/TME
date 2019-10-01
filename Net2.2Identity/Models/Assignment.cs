using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TME.Models
{
  public class Assignment : BaseClass
  {
    public Guid Id { get; set; }
    public Guid TeamId { get; set; }
    public virtual Team Team { get; set; }
    public Guid MentorId { get; set; }
    public virtual Mentor Mentor { get; set; }

    public bool IsActive { get; set;}
    public string Status { get; set; }
  }
}
