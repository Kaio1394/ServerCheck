using ServiceCheck.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCheck.Repositories
{
    public class WebApiServersRepository
    {
        private readonly ServiceCheckDbContext _context;
        public WebApiServersRepository(ServiceCheckDbContext context)
        {
            _context = context;
        }
    }
}
