using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApp.Controllers
{
    public class ReadersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}