using System;
using AnekdotBot.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnekdotBot.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("Hell33o");
        }

        public IActionResult Test()
        {
            RzuJoke r=new RzuJoke();
            string s = r.Get(Category.Anekdot18).Result;

            return Content(s);
        }
    }
}
