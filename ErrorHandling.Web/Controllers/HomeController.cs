using ErrorHandling.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ErrorHandling.Web.Filter;

namespace ErrorHandling.Web.Controllers
{
   // [CustomHandleExceptionFilterAttribute(ErroPage = "Hata1")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            int value1 = 5, value2 = 0;
            int result = value1 / value2;
            return View();
        }

        public IActionResult Privacy()
        {
            throw new FileNotFoundException();
            return View();
        }

        [AllowAnonymous]

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {

            var exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.Path = exception.Path;
            ViewBag.Message = exception.Error.Message;

            return View();

          //  return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Hata1()
        {
            return View();
        }

        public IActionResult Hata2()
        {
            return View();
        }
    }
}
