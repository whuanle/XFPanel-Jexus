using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XFPanelJexus.Web.Models.SqlService
{
    public class JexusSql
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        [Required]
        public Guid GuidID { get; set; }
        /// <summary>
        /// 文件提取码
        /// </summary>
        [Required]
        public string DownM { get; set; }
        [Required]
        public string Email { get; set; }
        
        public DateTime DateTime { get; set; }

        /// <summary>
        /// 配置文件类型
        /// Jexus or Nginx
        /// </summary>
        [Required]
        public string SHType { get; set; }
        [Required]
        public string FilePath { get; set; }
        [Required]
        public string Sitename { get; set; }
    }
}
