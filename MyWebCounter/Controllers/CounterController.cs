using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWebCounter.Models;
using System.Diagnostics;

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
            IncrementModel incrementModel = new IncrementModel();
            incrementModel.Count = _count;
            return View(incrementModel);
        }
        
        [HttpPost]
        public IActionResult Increment()
        {
            _count++;
            IncrementModel incrementModel = new IncrementModel();
            incrementModel.Count = _count;
            return View("Index", incrementModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}