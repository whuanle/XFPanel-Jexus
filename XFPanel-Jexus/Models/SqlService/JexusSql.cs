using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XFPanelJexus.Web.Models.SqlService
{
    public class JexusSql
    {
        public int ID { get; set; }

        /// <summary>
        /// 提取码
        /// </summary>
        public int NameID { get; set; }
        public string Email { get; set; }
        public DateTime DateTime { get; set; }
        public string FilePath { get; set; }
    }
}
