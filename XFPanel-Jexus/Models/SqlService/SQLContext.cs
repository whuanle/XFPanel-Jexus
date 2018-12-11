using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XFPanelJexus.Web.Models.SqlService
{
    public class SQLContext:DbContext
    {
        public SQLContext(DbContextOptions<SQLContext> options) : base(options)
        {
            
        }
        public DbSet<JexusSql> jexusSqls { get; set; }
    }
}
