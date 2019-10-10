using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public async Task<IActionResult> AddMentor(IFormFile file, IFormFile resume, Mentor mentor)
    {

      if (file == null || file.Length == 0)
      {

      }
      else
      {
        var nam = Guid.NewGuid();
        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "passport", nam.ToString() + file.FileName);
        var path2 = Path.Combine("passport", nam.ToString() + file.FileName);

        using (var stream = new FileStream(path, FileMode.Create))
        {
          await file.CopyToAsync(stream);
          mentor.ImageUrl = path2;
        }

      }


      if (resume == null || resume.Length == 0)
      {

      }
      else
      {
        var nam = Guid.NewGuid();

        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "profile", nam.ToString() + resume.FileName);
        var path2 = Path.Combine("profile", nam.ToString() + resume.FileName);

        using (var stream = new FileStream(path, FileMode.Create))
        {
          await file.CopyToAsync(stream);
          mentor.ProfileUrl = path2;
        }

      }



      //if (mentor == null)
      //{
      //  return Json(new
      //  {
      //    msg = "No Data"
      //  }
      // );
      //}

      mentor.Id = Guid.NewGuid();
      mentor.IsActive = true;
      mentor.FullName = mentor.FirstName + " " + mentor.LastName;
      //mentor.

      try
      {

        _context.Add(mentor);
        _context.SaveChanges();

        return RedirectToAction("Index");

      }
      catch (Exception ee)
      {

      }

      return RedirectToAction("Index");
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
      var mentors = _context.Mentors;


      var metid = mentids.Split(',');

      //mentor.

      try
      {

        foreach (var item in metid)
        {
          if(item != "")
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
      var mentors = _context.Mentors;


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
      var mentors = _context.Mentors;


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