using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XFPanelJexus.Web.Models.JexusModel
{
    public class JexusModel
    {
      /// <summary>
      /// 反向代理
      /// </summary>
        public string reproxy { get; set; }
        /// <summary>
        /// Url重写
        /// </summary>
        public string rewrite { get; set; }

        /// <summary>
        /// 是否关闭日志功能
        /// yes or no
        /// </summary>
        public string nolog { get; set; }

        /// <summary>
        /// 是否开启压缩
        /// </summary>
        public string usegzip { get; set; }

        /// <summary>
        /// ip白名单
        /// </summary>
        public string allowfrom { get; set; }

        /// <summary>
        /// ip黑名单
        /// </summary>
        public string denyfrom { get; set; }
        /// <summary>
        /// 是否对URL进行检测
        /// 默认为true
        /// </summary>
        public string checkquery { get; set; }
        
    }
}
