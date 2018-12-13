using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XFPanelJexus.Web.Models
{
    public class JexusOptions
    {
        /// <summary>
        /// 配置文件名称
        /// </summary>
        
            [Required(ErrorMessage ="网站配置文件名不能为空")]
            [StringLength(10,ErrorMessage ="尽量不要超过10个字符")]
            [RegularExpression(@"^[A-Za-z]*$",ErrorMessage ="只能输入字母")]
        public string Sitename { get; set; }

        [Required(ErrorMessage ="请输入你的邮箱")]
        [EmailAddress(ErrorMessage ="你输入的不是邮箱地址")]
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
