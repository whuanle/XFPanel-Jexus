using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XFPanel_Jexus.Models;
using XFPanelJexus.Web.Models;
using XFPanelJexus.Web.Models.Service;
using XFPanelJexus.Web.Models.SqlService;
namespace XFPanel_Jexus.Controllers
{
    public class HomeController : Controller
    {
        private SQLContext _sqlContext;
        public HomeController(SQLContext context)
        {
            _sqlContext = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult JexusSH(JexusOptions jexusOptions)
        {
            JexusSH jexusSH = new JexusSH(jexusOptions);
            jexusSH.JexusOneSH();
            jexusSH.JexusWebSH();
            jexusSH.JexsModelSH();
            CreateDir createDir = new CreateDir();

            JexusSql jexusSql = new JexusSql();
            jexusSql.Email = jexusOptions.email;

            createDir.CreateJexusSh(jexusSH.Re(), _sqlContext, jexusSql);
            return View(jexusSH.Re());
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
