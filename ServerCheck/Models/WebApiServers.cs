using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCheck.Models
{
    [Table("web_api_servers")]
    public class WebApiServers: ModelBase
    {
        public string? Host {  get; set; }  
        public int Port { get; set; }
    }
}
