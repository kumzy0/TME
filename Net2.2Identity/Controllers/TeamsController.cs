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
    public class TeamsController : Controller
    {

    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public TeamsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
      _context = context;
      _userManager = userManager;

    }

    public IActionResult Index()
        {
      var teams = _context.Teams.ToList();
            return View(teams);
        }

    public IActionResult TeamInfo()
    {
      return View();
    }

    [HttpPost]
    public IActionResult AddTeam([FromBody]Team team)
    {
      if (team == null)
      {
        return Json(new
        {
          msg = "No Data"
        }
       );
      }

      team.Id = Guid.NewGuid();
      team.IsActive = true;
      //mentor.

      try
      {

        _context.Add(team);
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