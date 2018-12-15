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
using XFPanelJexus.Web.Models.JexusModel;

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

        /// <summary>
        /// 创建 Jexus 配置文件
        /// 表单检查
        /// </summary>
        /// <param name="jexusOptions">Jexus配置</param>
        /// <returns>视图</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateJexus(JexusOptions jexusOptions)
        {
            //表单检查
            if (!ModelState.IsValid)
            {
                return View(jexusOptions);
            }
            
            //构建配置文件内容
            JexusSH jexusSH = new JexusSH(jexusOptions);
            await jexusSH.JexusBuild();

            //构建配置文件及生成数据库数据
            CreateDirOrFile createDirOrFile = new CreateDirOrFile();
            JexusSql jexusSql = new JexusSql();
            jexusSql.Email = jexusOptions.email;
            jexusSql.Sitename = jexusOptions.Sitename;
            jexusSql.SHType = "Jexus";

            var jq =await createDirOrFile.CreateJexusSh(jexusSH.Re(), _sqlContext, jexusSql);
            ViewBag.host = HttpContext.Request.Host;

            return Redirect("./JexusSH?DownM=" + jq.DownM);
           
        }
        [HttpGet]
        public IActionResult CreateJexus()
        {
            return View();
        }
        public IActionResult JexusSH(string DownM)
        {
            if (DownM == null)
                return NotFound();
            ViewBag.DownM = DownM;
            ViewBag.host = HttpContext.Request.Host;
            return View();
        }

        /// <summary>
        /// 返回文件流
        /// </summary>
        /// <param name="DownM">文件码</param>
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
            return NotFound();
        }

        /// <summary>
        /// 查找配置文件记录
        /// </summary>
        /// <param name="str">查找字符索引</param>
        /// <param name="type">类型，文件码或邮箱</param>
        /// <returns>视图</returns>
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
        /// 通过文件码查找记录
        /// </summary>
        /// <returns>地址</returns>
        public IEnumerable<JexusSql> SelectDownM(string DownM)
        {
            if (DownM == null || DownM == string.Empty)
                return null;
            var selectlist = _sqlContext.jexusSqls.Where(m => m.DownM == DownM).ToList();
            if (selectlist == null)
                return null;

            return selectlist;

        }
        /// <summary>
        /// 通过邮件地址查找记录
        /// </summary>
        /// <param name="email">邮件地址</param>
        /// <returns></returns>
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
