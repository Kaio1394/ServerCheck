using ServiceCheck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCheck.Repositories.Interfaces
{
    public interface IWebApiServersRepository
    {
        Task<IEnumerable<WebApiServers>> GetAllWebApiServers();
        Task<WebApiServers> GetWebApiServerByUuid(string uuid);
        Task AddWebApiServer(WebApiServers webApiServers);
    }
}
