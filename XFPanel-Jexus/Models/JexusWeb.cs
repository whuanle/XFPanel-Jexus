using System;
using System.Collections.Generic;
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
        public string CmdLine { get; set; }
        /// <summary>
        /// 网站根目录
        /// </summary>
        public string AppRoot { get; set; }   

        /// <summary>
        /// ASP.NET Core 程序端口
        /// </summary>
        public int Port { get; set; }

    }
}
