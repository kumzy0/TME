using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Net2._2Identity.Data;
using Net2._2Identity.Models;

namespace TME.Controllers
{
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
            return View();
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


  }
}