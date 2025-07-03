using Microsoft.EntityFrameworkCore;
using ServerCheck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCheck.Data
{
    public class ServerCheckDbContext: DbContext
    {
        public DbSet<WebApiServers> WebApiServers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=ServerCheck.db");
    }
}
