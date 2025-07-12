using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ServerCheck.Models
{
    [ExcludeFromCodeCoverage]
    public class Process
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("usageMemory")]
        public string? UsageMemory { get; set; }

        [JsonIgnore]
        public long UsageMemoryAux { get; set; }
    }
}
