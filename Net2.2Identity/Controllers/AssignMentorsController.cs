using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TME.Controllers
{
    public class AssignMentorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}