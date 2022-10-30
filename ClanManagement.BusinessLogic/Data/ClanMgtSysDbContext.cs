using ClanManagement.BusinessLogic.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClanManagement.BusinessLogic.Data
{
    public class ClanMgtSysDbContext : DbContext

    {
        public ClanMgtSysDbContext(DbContextOptions<ClanMgtSysDbContext> options) : base(options)
        {

        }
        
        public DbSet<Clan> Clan { get; set; }
        public DbSet<ClanMotto> ClanMotto { get; set; }
        public DbSet<Name> Name { get; set; }
    }
}
