﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using XFPanelJexus.Web.Models.SqlService;
using Microsoft.EntityFrameworkCore;

namespace XFPanelJexus.Web.Models.Service
{
    /// <summary>
    /// 创建目录或文件
    /// </summary>
    public class CreateDirOrFile
    {
        public static string rootDir = Directory.GetCurrentDirectory();
        public static string shDir = rootDir + @"/" + "SHDir";
        static CreateDirOrFile()
        {
            if (!Directory.Exists(shDir))
            {
                Directory.CreateDirectory(shDir);
            }
        }

        public async Task<JexusSql> CreateJexusSh(List<string> shList, SQLContext context, JexusSql jexusSql)
        {
            string dirPath = shDir + @"/" + DateTime.Now.Date.ToString("yyyyMMdd");
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            string filename = DateTime.Now.ToString("yyyyMMddHHmmssff");
            var filepath = dirPath + @"/" + filename + ".sh";

            //在硬盘中写入文件、在数据库中生成数据
            await Task.Run(() =>
            {
                FileStream fileStream = new FileStream(filepath, FileMode.Create);
                StreamWriter streamWriter = new StreamWriter(fileStream);
                //写入命令到 sh
                streamWriter.WriteLine("cd /usr/jexus/siteconf");
                streamWriter.WriteLine("echo >" + jexusSql.Sitename);
                foreach (var i in shList)
                {
                    streamWriter.WriteLine(@"echo " + "\"" + i + "\"");
                }

                streamWriter.WriteLine("cd /usr/jexus");
                streamWriter.WriteLine("./jws strat " + jexusSql.Sitename);
                //写入结束
                streamWriter.Close();
                fileStream.Close();
                //写入数据库
                jexusSql.DateTime = DateTime.Now;
                jexusSql.FilePath = filepath;
                jexusSql.DownM = filename;
                context.jexusSqls.Add(jexusSql);
                context.SaveChanges();
            });
            return jexusSql;
        }
    }
}
