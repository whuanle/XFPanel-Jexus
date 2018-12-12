﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace XFPanel_Jexus
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var sqlpath = Directory.GetCurrentDirectory()+"/"+"SQLFile";
            if (!Directory.Exists(sqlpath))
                Directory.CreateDirectory(sqlpath);

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
