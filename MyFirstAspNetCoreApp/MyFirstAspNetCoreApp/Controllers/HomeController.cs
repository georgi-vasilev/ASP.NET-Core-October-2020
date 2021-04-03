using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyFirstAspNetCoreApp.Data;
using MyFirstAspNetCoreApp.Models;
using MyFirstAspNetCoreApp.Services;
using MyFirstAspNetCoreApp.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAspNetCoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext db;
        private readonly IInstanceCounter instanceCounter;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db, IInstanceCounter instanceCounter)
        {
            _logger = logger;
            this.db = db;
            this.instanceCounter = instanceCounter;
        }

        public IActionResult Index(int id)
        {
            /*
                         SIDE NOTES
            //Note from lecture: if you have time use ViewModel rather than 
            //ViewData or ViewBag since ViewData is like dictionary
            //and ViewBag is dynamic

            //ViewData is like Dictionary<string,obj>
            this.ViewData["Year"] = 2021;
            this.ViewData["Name"] = "Gopski";
            this.ViewData["UsersCount"] = this.db.Users.Count();


            //dynamic ViewBag
            this.ViewBag.Name = "Gopski";
            this.ViewBag.Year = 2021;
            this.ViewBag.UsersCount = this.db.Users.Count();
            this.ViewBag.Calc = new Func<int>(() => 3);
            this.ViewBag.Calc();
            //Note: if you change the value of ViewBag will also change the value
            //of the ViewData above

            */
            var viewModel = new IndexViewModel
            {
                Id = id,
                Name = "Gopski",
                Year = DateTime.UtcNow.Year,
                ProcessorCount = Environment.ProcessorCount,
                UsersCount = this.db.Users.Count()
            };

            return View(viewModel);
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
