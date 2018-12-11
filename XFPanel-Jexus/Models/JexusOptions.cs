using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XFPanelJexus.Web.Models
{
    public class JexusOptions
    {
        public string filename { get; set; }
        public string email { get; set; }
            
         /// <summary>
        /// 外界设置
        /// </summary>
        public JexusOne JexusOne { get; set; }

        /// <summary>
        /// 网站内网设置
        /// </summary>
        public JexusWeb JexusWeb { get; set; }

        /// <summary>
        /// 高级设置
        /// </summary>
        public JexusModel JexusModel { get; set; }
    }
}
