﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XFPanelJexus.Web.Models
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
        /// 网站首页文件名
        /// 对于asp.net core 程序，不需要填
        /// </summary>
        public string indexs { get; set; }

        /// <summary>
        /// 是否使用长连接
        /// 默认为长连接
        /// true
        /// </summary>
        public string keep_alive { get; set; }

        /// <summary>
        /// 禁止访问目录
        /// 相对网站根目录
        /// </summary>
        public string DenyDirs { get; set; }

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