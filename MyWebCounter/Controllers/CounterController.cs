using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyWebCounter.Controllers
{
    public class CounterController : Controller
    {
        int i = 0;
        public IActionResult Index()
        {
            i++;
            ViewData["Count"] = i.ToString();

            return View();
        }        
    }
}