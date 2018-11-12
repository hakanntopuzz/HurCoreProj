﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HurCoreProj.Web.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace HurCoreProj.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [Route("Error/404")]
        public IActionResult Error404()
        {
            return View();
        }

        [Route("Error/400")]
        public IActionResult Error400()
        {
            return View();
        }
    }
}
