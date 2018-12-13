using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XFPanelJexus.Web.Models
{
    /// <summary>
    /// 配置kestrel服务器
    /// AppHost={}
    /// 以;分隔每一行
    /// </summary>
    public class JexusWeb
    {
        /// <summary>
        /// 后台运行
        /// dotnet /var/www/XfFile/Xffiles.Web.dll;
        /// </summary>

         [Required(ErrorMessage ="必须填写网站启动的dll文件绝对路径")]
        public string CmdLine { get; set; }
        /// <summary>
        /// 网站根目录
        /// </summary>
        public string AppRoot { get; set; }

        /// <summary>
        /// ASP.NET Core 程序端口
        /// </summary>
        
        [Required(ErrorMessage = "必须填写，否则无法访问你的网站")]
        [Range(1, 99999, ErrorMessage = "端口值超出范围")]
        public int Port { get; set; }

    }
}
