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
using TME.ViewModel;

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

    public IActionResult TeamInfo(Guid id)
    {
      var team = _context.Teams.FirstOrDefault(x => x.Id == id);
      var members = _context.Members.Where(x => x.TeamId == id).ToList();

      TeamInfoViewModel tiVM = new TeamInfoViewModel();

      tiVM.Team = team;
      tiVM.TeamMember = members;


      return View(tiVM);
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

    [HttpPost]
    public IActionResult AddMembers([FromBody]Member member)
    {
      if (member == null)
      {
        return Json(new
        {
          msg = "No Data"
        }
       );
      }

      member.Id = Guid.NewGuid();
      member.IsActive = true;
      //mentor.

      try
      {

        _context.Add(member);
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