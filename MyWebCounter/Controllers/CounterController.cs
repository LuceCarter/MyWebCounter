using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWebCounter.Models;

namespace MyWebCounter.Controllers
{
    public class CounterController : Controller
    {
        private readonly ILogger<CounterController> _logger;
        public static int _count = 0;

        public CounterController(ILogger<CounterController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            IncrementViewModel incrementViewModel = new IncrementViewModel();
            incrementViewModel.Count = _count;
            return View(incrementViewModel);
        }
        
        [HttpPost]
        public IActionResult Increment()
        {
            _count++;
            IncrementViewModel incrementViewModel = new IncrementViewModel();
            incrementViewModel.Count = _count;
            return View("Index", incrementViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}