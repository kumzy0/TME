﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TME.Controllers
{
    public class TeamsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    public IActionResult TeamInfo()
    {
      return View();
    }

  }
}