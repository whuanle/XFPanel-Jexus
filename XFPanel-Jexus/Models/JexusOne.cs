using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XFPanelJexus.Web.Models
{
    public class JexusOne
    {
        /// <summary>
        /// 域名
        /// </summary>
        [Required(ErrorMessage ="请填写域名")]
        public string hosts { get; set; }

        /// <summary>
        /// 外部端口
        /// </summary>
        
        [Required(ErrorMessage = "没有特殊情况请填写 80")]
        [Range(1,99999,ErrorMessage ="端口值超出范围")]
        public int ports { get; set; }
        /// <summary>
        /// 网站根目录
        /// root=/ /xxxx
        /// </summary>

        [Required(ErrorMessage ="网站目录路径不能为空！")]
        public string root { get; set; }
    }
}
