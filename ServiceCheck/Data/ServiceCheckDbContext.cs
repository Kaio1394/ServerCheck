using Microsoft.EntityFrameworkCore;
using ServiceCheck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCheck.Data
{
    public class ServiceCheckDbContext: DbContext
    {
        public DbSet<WebApiServers> WebApiServers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=ServiceCheck.db");
    }
}
