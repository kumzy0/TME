using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Net2._2Identity.Data;
using Net2._2Identity.Models;
using TME.Models;
using TME.ViewModel;

namespace TME.Controllers
{
  [Authorize]

  public class AssignMentorsController : Controller
    {
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public AssignMentorsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
      _context = context;
      _userManager = userManager;

    }

    public IActionResult Index()
        {

      ViewData["Mentors"] = new SelectList(_context.Mentors, "Id", "FullName");
      ViewData["Teams"] = new SelectList(_context.Teams, "Id", "VentureName");

      var assignment = _context.Assignments.Include(x => x.Mentor).Include(x => x.Team).ToList();

      return View(assignment);
        }

    [Produces("application/json")]
    [HttpGet("search")]
    [Route("/api/AssignMentor/SearchTeam")]
    public async Task<IActionResult> SearchTeam()
    {

      try
      {
        string term = HttpContext.Request.Query["term"].ToString();
        var names = _context.Teams.Where(p => p.VentureName.Contains(term)).Select(p => p.VentureName).ToList();
        return Ok(names);
      }
      catch
      {
        return BadRequest();
      }

    }

    [HttpPost]
    public IActionResult Assign([FromBody]MentorTeam mentorA)
    {
      if (mentorA == null)
      {
        return Json(new
        {
          msg = "No Data"
        }
       );
      }

      Assignment ass = new Assignment()
      {
        Id = Guid.NewGuid(),
        MentorId = mentorA.MentorId,
        TeamId = mentorA.TeamId,
        IsActive = true,
        
      };

      //mentor.

      try
      {

        _context.Add(ass);
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
    public IActionResult Delete([FromBody]string mentids)
    {
      if (mentids == null)
      {
        return Json(new
        {
          msg = "No Data"
        }
       );
      }
      var mentors = _context.Assignments;


      var metid = mentids.Split(',');

      //mentor.

      try
      {

        foreach (var item in metid)
        {
          if (item != "")
          {
            var mm = mentors.FirstOrDefault(s => s.Id == Guid.Parse(item));

            mm.IsActive = true;

            _context.Remove(mm);
            _context.SaveChanges();

          }
        }


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
    public IActionResult SetActive([FromBody]string mentids)
    {
      if (mentids == null)
      {
        return Json(new
        {
          msg = "No Data"
        }
       );
      }
      var mentors = _context.Assignments;


      var metid = mentids.Split(',');

      //mentor.

      try
      {

        foreach (var item in metid)
        {
          if (item != "")
          {
            var mm = mentors.FirstOrDefault(s => s.Id == Guid.Parse(item));

            mm.IsActive = true;

            _context.Update(mm);
            _context.SaveChanges();

          }
        }


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
    public IActionResult SetInActive([FromBody]string mentids)
    {
      if (mentids == null)
      {
        return Json(new
        {
          msg = "No Data"
        }
       );
      }
      var mentors = _context.Assignments;


      var metid = mentids.Split(',');

      //mentor.

      try
      {

        foreach (var item in metid)
        {
          if (item != "")
          {
            var mm = mentors.FirstOrDefault(s => s.Id == Guid.Parse(item));

            mm.IsActive = false;

            _context.Update(mm);
            _context.SaveChanges();

          }
        }


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