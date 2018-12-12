﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using XFPanelJexus.Web.Models.SqlService;

namespace XFPanelJexus.Web.Migrations
{
    [DbContext(typeof(SQLContext))]
    partial class SQLContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("XFPanelJexus.Web.Models.SqlService.JexusSql", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("DownM");

                    b.Property<string>("Email");

                    b.Property<string>("FilePath");

                    b.Property<int>("NameID");

                    b.Property<string>("Sitename");

                    b.HasKey("ID");

                    b.ToTable("jexusSqls");
                });
#pragma warning restore 612, 618
        }
    }
}
