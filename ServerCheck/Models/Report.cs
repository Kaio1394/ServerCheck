using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ServerCheck.Models
{
    class Report
    {
        [JsonPropertyName("memory")]
        public Models.Memory? Memory { get; set; }

        [JsonPropertyName("cpu")]
        public Models.Cpu? Cpu { get; set; }

        [JsonPropertyName("listDisk")]
        public IEnumerable<Models.Disk> ListDisk { get; set; } = new List<Models.Disk>();
        
        [JsonPropertyName("process")]
        public IEnumerable<Models.Process> Process { get; set; } = new List<Models.Process>();
        
        [JsonPropertyName("services")]
        public IEnumerable<Models.Service> Services { get; set; } = new List<Models.Service>();
    }
}
