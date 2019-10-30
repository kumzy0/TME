using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
      var members = _context.Members.ToList();

      List<TeamView> tvList = new List<TeamView>();
      TeamView tv;

      foreach (var item in teams)
      {
        tv = new TeamView();

        tv.Team = item;
        tv.TeamMember = members.Where(x => x.TeamId == item.Id).Count();

        tvList.Add(tv);

      }



            return View(tvList);
        }

    public IActionResult TeamInfo(Guid id)
    {
      var team = _context.Teams.FirstOrDefault(x => x.Id == id);
      var members = _context.Members.Where(x => x.TeamId == id).ToList();
      var assignment = _context.Assignments.Where(x => x.TeamId == id).Include(x => x.Mentor).ToList();

      TeamInfoViewModel tiVM = new TeamInfoViewModel();

      tiVM.Team = team;
      tiVM.TeamMember = members;
      tiVM.Assignments = assignment;

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

    [HttpPost]
    public IActionResult EditMembers([FromBody]Member member)
    {
      if (member == null)
      {
        return Json(new
        {
          msg = "No Data"
        }
       );
      }

      var mm = _context.Members.FirstOrDefault(x => x.Id == member.Id);




      try
      {
        mm.FirstName = member.FirstName;
        mm.NickName = member.NickName;
        mm.LastName = member.LastName;
        mm.Email = member.Email;
        mm.PhoneNumberMobile = member.PhoneNumberMobile;
        mm.PhoneNumberWork = member.PhoneNumberWork;
        mm.Address = member.Address;
        mm.City = member.City;
        mm.Province = member.Province;
        mm.Country = member.Country;
        mm.Education = member.Education;

        _context.Update(mm);
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
    public IActionResult DeleteMember([FromBody]Guid id)
    {
      if (id == null)
      {
        return Json(new
        {
          msg = "No Data"
        }
       );
      }
      var member = _context.Members.FirstOrDefault(x => x.Id == id);


      try
      {

            _context.Remove(member);
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
      var mentors = _context.Teams;


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
      var mentors = _context.Teams;


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
      var mentors = _context.Teams;


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


  }
}