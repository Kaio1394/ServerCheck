using Microsoft.EntityFrameworkCore;
using ServerCheck.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ServerCheck.Data
{
    public class ServerCheckDbContext: DbContext
    {
        public ServerCheckDbContext() : base(new DbContextOptionsBuilder<ServerCheckDbContext>()
                .UseSqlite($"Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ServerCheck.db")}")
                .Options)
        {
        }
        public DbSet<WebApiServers> WebApiServers { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseSqlite("Data Source=ServerCheck.db");
    }
}
