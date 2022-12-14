// <auto-generated />
using System;
using ClanManagement.BusinessLogic.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClanManagement.BusinessLogic.Data.Migrations
{
    [DbContext(typeof(ClanMgtSysDbContext))]
    [Migration("20221030110209_createdatabase")]
    partial class createdatabase
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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClanLeader")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("clan_leader");

                    b.Property<string>("ClanMotto")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("clan_motto");

                    b.Property<string>("ClanSeat")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("clan_seat");

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

                    b.ToTable("clan");
                });
#pragma warning restore 612, 618
        }
    }
}
