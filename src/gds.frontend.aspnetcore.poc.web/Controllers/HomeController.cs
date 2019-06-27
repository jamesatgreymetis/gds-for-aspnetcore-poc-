using System.Diagnostics;
using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using gds.frontend.aspnetcore.poc.web.Models;

namespace gds.frontend.aspnetcore.poc.web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("/")]
        [Route("/{component}")]
        [Route("/index/{component}")]
        public IActionResult Index(string component)
        {
            return View(component ?? "Button");
        }

        [HttpGet]
        [Route("/Table")]
        public IActionResult Table()
        {            
            return View("Table");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
