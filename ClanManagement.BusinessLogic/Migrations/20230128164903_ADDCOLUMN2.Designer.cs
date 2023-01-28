﻿// <auto-generated />
using System;
using ClanManagement.BusinessLogic.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClanManagement.BusinessLogic.Migrations
{
    [DbContext(typeof(ClanMgtSysDbContext))]
    [Migration("20230128164903_ADDCOLUMN2")]
    partial class ADDCOLUMN2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClanManagement.BusinessLogic.Data.Models.Clan", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id");

                    b.Property<string>("ClanLeader")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("clan_leader");

                    b.Property<string>("ClanSeat")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("clan_seat");

                    b.Property<string>("Lang")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("lang_id");

                    b.Property<string>("MinorTotem")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("minor_totem");

                    b.Property<string>("MottoId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("Totem")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("totem");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Clan");
                });

            modelBuilder.Entity("ClanManagement.BusinessLogic.Data.Models.ClanMotto", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id");

                    b.Property<string>("Motto")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("motto");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ClanMotto");
                });

            modelBuilder.Entity("ClanManagement.BusinessLogic.Data.Models.Language", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit")
                        .HasColumnName("isDefault");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Language");
                });

            modelBuilder.Entity("ClanManagement.BusinessLogic.Data.Models.Name", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id");

                    b.Property<string>("ClanId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Names")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClanId");

                    b.ToTable("Name");
                });

            modelBuilder.Entity("ClanManagement.BusinessLogic.Data.Models.Name", b =>
                {
                    b.HasOne("ClanManagement.BusinessLogic.Data.Models.Clan", null)
                        .WithMany("ClanId")
                        .HasForeignKey("ClanId");
                });

            modelBuilder.Entity("ClanManagement.BusinessLogic.Data.Models.Clan", b =>
                {
                    b.Navigation("ClanId");
                });
#pragma warning restore 612, 618
        }
    }
}