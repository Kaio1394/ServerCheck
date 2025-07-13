using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ServerCheck.Models.Response
{
    class ResponseScriptOutput
    {
        [JsonPropertyName("pathExecutable")]
        public string? PathExecutable { get; set; }
        [JsonPropertyName("output")]
        public string? Output { get; set; }
    }
}
