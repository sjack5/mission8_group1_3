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

        public HomeController(ILogger<HomeController> logger, QuadrantContext x)
        {
            _QuadrantContext = x;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddEdit()
        {
            ViewBag.Category = _QuadrantContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult AddEdit(Quadrants_Model qm)
        {
            if (ModelState.IsValid)
            {
                _QuadrantContext.Add(qm);
                _QuadrantContext.SaveChanges();

                var actions = _QuadrantContext.Responses.ToList();
                return View("QuadrantView", actions);
                
            }
            else
            {
                return View();
            }
        }

        public IActionResult QuadrantView()
        {
            var tasks = _QuadrantContext.Responses.ToList();
            return View(tasks);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Category = _QuadrantContext.Categories.ToList();
            var task_edit = _QuadrantContext.Responses.Single(x => x.taskId == id);

            return View("AddEdit", task_edit);
        }

        [HttpPost]
        public IActionResult Edit(Quadrants_Model x)
        {
            ViewBag.Categories = _QuadrantContext.Categories.ToList();

            if (ModelState.IsValid)
            {
                _QuadrantContext.Update(x);
                _QuadrantContext.SaveChanges();

                return RedirectToAction("QuadrantView");
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public IActionResult Delete (int id)
        {
            var task_delete = _QuadrantContext.Responses.Single(x => x.taskId == id);
            _QuadrantContext.Responses.Remove(task_delete);
            _QuadrantContext.SaveChanges();

            return RedirectToAction("QuadrantView");
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
