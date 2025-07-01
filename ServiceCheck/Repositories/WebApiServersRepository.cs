using Microsoft.EntityFrameworkCore;
using ServiceCheck.Data;
using ServiceCheck.Models;
using ServiceCheck.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCheck.Repositories
{
    public class WebApiServersRepository: IWebApiServersRepository
    {
        private readonly ServiceCheckDbContext _context;
        public WebApiServersRepository(ServiceCheckDbContext context)
        {
            _context = context;
        }

        public async Task AddWebApiServer(WebApiServers webApiServers)
        {
            await _context.WebApiServers.AddAsync(webApiServers);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<WebApiServers>> GetAllWebApiServers()
        {
            var listWebApiServers = await _context.WebApiServers.ToListAsync();
            return listWebApiServers;
        }

        public async Task<WebApiServers> GetWebApiServerByUuid(string uuid)
        {
            WebApiServers? webApiServer = await _context.WebApiServers.FirstOrDefaultAsync(x => x.Uuid == uuid);
            return webApiServer;
        }
    }
}
