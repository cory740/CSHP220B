using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CEby_Homework6.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BirthdayCardForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BirthdayCardForm(Models.BirthdayCard birthdayCard)
        {
            if (ModelState.IsValid)
            {
                return View("Sent", birthdayCard);
            }
            else
            {
                return View();
            }
        }
    }
}