using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XFPanel_Jexus.Models;
using XFPanelJexus.Web.Models;
using XFPanelJexus.Web.Models.Service;

namespace XFPanel_Jexus.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult JexusSH(JexusOptions jexusOptions)
        {
            JexusSH jexusSH = new JexusSH(jexusOptions);
            return View();
        }
        [HttpGet]
        public IActionResult JexusSH()
        {
            return View("./Index.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
