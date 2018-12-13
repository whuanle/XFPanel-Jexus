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
        private readonly SQLContext _sqlContext;
        public HomeController(SQLContext context)
        {
            _sqlContext = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateJexus(JexusOptions jexusOptions)
        {
            if (!ModelState.IsValid)
            {
                return View(jexusOptions);
            }
            JexusSH jexusSH = new JexusSH(jexusOptions);
            jexusSH.JexusOneSH();
            jexusSH.JexusWebSH();
            jexusSH.JexsModelSH();
            CreateDir createDir = new CreateDir();

            JexusSql jexusSql = new JexusSql();
            jexusSql.Email = jexusOptions.email;
            jexusSql.Sitename = jexusOptions.Sitename;
            jexusSql.SHType = "Jexus";
            var jq = createDir.CreateJexusSh(jexusSH.Re(), _sqlContext, jexusSql);
            ViewBag.host = HttpContext.Request.Host;

            return RedirectToAction(nameof(JexusSH), jq);
        }
        [HttpGet]
        public IActionResult CreateJexus()
        {
            return View();
        }
        public IActionResult JexusSH(JexusSql jexusSql)
        {
            if (jexusSql == null)
                return View();

            return View(jexusSql);
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

            return File(stream, "application/x-sh", DownM + ".sh");
        }
        public IActionResult DownSH()
        {
            return View("./Index.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Select(string str, string type)
        {
            if (str == null || type == null || (type != "DownM" && type != "email"))
                return View();

            if (type == "DownM")
            {
                ViewBag.DownM = str;
                return View(SelectDownM(str));
            }
            ViewBag.host = HttpContext.Request.Host;
            ViewBag.email = str;
            return View(SelectEmail(str));
        }

        [HttpGet]
        public IActionResult Select()
        {
            return View();
        }
        /// <summary>
        /// 查找记录
        /// </summary>
        /// <returns></returns>
        public IEnumerable<JexusSql> SelectDownM(string DownM)
        {
            if (DownM == null || DownM == string.Empty)
                return null;
            var selectlist = _sqlContext.jexusSqls.Where(m => m.DownM == DownM).ToList();
            if (selectlist == null)
                return null;

            return selectlist;

        }

        public IEnumerable<JexusSql> SelectEmail(string email)
        {
            if (email == null || email == string.Empty)
                return null;

            var selectlist = _sqlContext.jexusSqls.Where(a => a.Email == email).OrderByDescending(a => a.DateTime).ToList();
            if (selectlist == null)
                return null;
            return selectlist;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
