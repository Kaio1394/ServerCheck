using Microsoft.EntityFrameworkCore;
using ServerCheck.Data;
using ServerCheck.Models;
using ServerCheck.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCheck.Repositories
{
    public class WebApiServersRepository: IWebApiServersRepository
    {
        private readonly ServerCheckDbContext _context;
        public WebApiServersRepository(ServerCheckDbContext context)
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
