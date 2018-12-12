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
using System.IO;
using Microsoft.AspNetCore.StaticFiles;

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
            jexusSql.Sitename = jexusOptions.Sitename;

            var jq = createDir.CreateJexusSh(jexusSH.Re(), _sqlContext, jexusSql);

            return View(jq);
        }
        [HttpGet]
        public IActionResult JexusSH()
        {
            return View("./Index.cshtml");
        }
        /// <summary>
        /// 返回文件
        /// </summary>
        /// <param name="DownM"></param>
        /// <returns></returns>
        [HttpGet]
        public FileResult DownSH(string DownM)
        {
            var path = _sqlContext.jexusSqls.FirstOrDefault(a => a.DownM == DownM.ToString()).FilePath;
            if (!System.IO.File.Exists(path)) return null;

            var stream = System.IO.File.OpenRead(path);

            return File(stream, "application/x-sh", DownM+".sh");
        }
        public IActionResult DownSH()
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
