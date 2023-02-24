using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mission8_group1_3.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace mission8_group1_3.Controllers
{
    public class HomeController : Controller
    {
        private QuadrantContext _QuadrantContext { get; set; }

        public HomeController(QuadrantContext x)
        {
            _QuadrantContext = x;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
