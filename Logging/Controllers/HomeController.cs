using Logging.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Logging.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{
 
        //    _logger.LogTrace("Index sayfasına girildi.");

        //    _logger.LogDebug("Debug sayfasını bilgilendirme");
        //    _logger.LogInformation("Index Sayfasına girildi");
        //    _logger.LogWarning("Index Sayfasına girildi");
        //    _logger.LogError("Index Sayfasına girildi");
        //    _logger.LogCritical("Index Sayfasına girildi");
        //    return View();
        //}


        private readonly ILoggerFactory _loggerFactory;

        public HomeController(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        public IActionResult Index()
        {
             var logger= _loggerFactory.CreateLogger("HomeSinifi");
            logger.LogTrace("Index Sayfasına Girildi");
            logger.LogDebug("Index Sayfasına Girildi");
            logger.LogInformation("Index Sayfasına Girildi");
            logger.LogWarning("Index Sayfasına Girildi");
            logger.LogError("Index Sayfasına Girildi");
            logger.LogCritical("Index Sayfasına Girildi");
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
