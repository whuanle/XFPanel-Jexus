using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XFPanelJexus.Web.Models
{
    public class JexusOne
    {
        /// <summary>
        /// 域名
        /// </summary>
        public string hosts { get; set; }

        /// <summary>
        /// 外部端口
        /// </summary>
        public int ports { get; set; }
        /// <summary>
        /// 网站根目录
        /// root=/ /xxxx
        /// </summary>
        public string root { get; set; }
    }
}
