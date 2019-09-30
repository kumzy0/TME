using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Net2._2Identity.Data;
using Net2._2Identity.Models;
using TME.Models;

namespace TME.Controllers
{
  [Authorize]
  public class MentorsController : Controller
    {

    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public MentorsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
      _context = context;
      _userManager = userManager;

    }

    public IActionResult Index()
    {

        var mentors = _context.Mentors.ToList();
        return View(mentors);
    }

    [HttpPost]
    public IActionResult AddMentor([FromBody]Mentor mentor)
    {
      if (mentor == null)
      {
        return Json(new
        {
          msg = "No Data"
        }
       );
      }

      mentor.Id = Guid.NewGuid();
      mentor.IsActive = true;
      //mentor.

      try
      {

        _context.Add(mentor);
        _context.SaveChanges();

        return Json(new
        {
          msg = "Success"
        }
  );
      }
      catch (Exception ee)
      {

      }

      return Json(
      new
      {
        msg = "Fail"
      });
    }

  }
}