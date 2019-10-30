using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Net2._2Identity.Data;
using Net2._2Identity.Models;
using TME.Models;

namespace TME.Controllers
{
    public class ManagerUsersController : Controller
    {
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ApplicationDbContext _context;

    public ManagerUsersController(
    UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager,
    ApplicationDbContext context)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _context = context;

    }


    public IActionResult Index()
        {
      var users = _context.Users.ToList();

      List<User> appUser = new List<User>();
      User singleUser;

      foreach (var item in users)
      {
        singleUser = new User();

        singleUser.Email = item.Email;
        singleUser.Name = item.FullName;
        singleUser.PhoneNumber = item.PhoneNumber;
        singleUser.Id = Guid.Parse(item.Id);
        singleUser.UserRole = item.UserRole;

        singleUser.Status = item.Status;

        appUser.Add(singleUser);
      }

            return View(appUser);
        }

    [HttpPost]
    public async Task<IActionResult> EditUser([FromBody]User user)
    {
      if (user == null)
      {
        return Json(new
        {
          msg = "No Data"
        }
       );
      }



      var userr = _userManager.FindByEmailAsync(user.Email).Result;
      var roles = await _userManager.GetRolesAsync(userr);


      userr.FullName = user.Name;
      userr.UserRole = user.UserRole;



      try
      {
        _context.Update(userr);
        _context.SaveChanges();

        foreach (var roleName in roles)
        {
          await _userManager.RemoveFromRoleAsync(userr, roleName);
        }

        await _userManager.AddToRoleAsync(userr, user.UserRole);


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
    public async Task<IActionResult> Deactivate([FromBody]string email)
    {
      if (email == null)
      {
        return Json(new
        {
          msg = "No Data"
        }
       );
      }

      var userr = _userManager.FindByEmailAsync(email).Result;

      userr.IsEnabled = false;
      userr.Status = "Not Active";


      try
      {
        _context.Update(userr);
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
    public async Task<IActionResult> Activate([FromBody]string email)
    {
      if (email == null)
      {
        return Json(new
        {
          msg = "No Data"
        }
       );
      }

      var userr = _userManager.FindByEmailAsync(email).Result;

      userr.IsEnabled = true;
      userr.Status = "Active";


      try
      {
        _context.Update(userr);
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
    public async Task<IActionResult> CreateUser(User newUser)
    {
      //var user = new ApplicationUser { UserName = newUser.Name, Email = newUser.Email };

      if (ModelState.IsValid)
      {
        var user = new ApplicationUser { UserName = newUser.Email, Email = newUser.Email, FullName = newUser.Name, PhoneNumber = newUser.PhoneNumber, UserRole = newUser.UserRole, Status = "Active" };
        var result = await _userManager.CreateAsync(user, newUser.Password);
        if (result.Succeeded)
        {
          await _userManager.AddToRoleAsync(user, newUser.UserRole);


          //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
          //var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
          //await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

          //await _signInManager.SignInAsync(user, isPersistent: false);
          //_logger.LogInformation("User created a new account with password.");
          return RedirectToAction("Index");
        }
        //AddErrors(result);
      }

      // If we got this far, something failed, redisplay form
      return RedirectToAction("Index");


    }
  }
}