using ErrorHandling.Web.Filter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorHandling.Web.Controllers
{

    //[CustomHandleExceptionFilterAttribute(ErroPage = "Hata2")]
    public class ProductController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IActionResult Index()
        {
            throw new Exception("Veri tabanında bir hata meydana geldi");
            return View();
        }


    }
}
