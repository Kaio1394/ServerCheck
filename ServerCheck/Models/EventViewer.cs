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
    public class EventView
    {
        [JsonPropertyName("entryType")]
        public string? EntryType { get; set; }
        [JsonPropertyName("source")]
        public string? Source { get; set; }
        [JsonPropertyName("message")]
        public string? Message { get; set; }
        [JsonPropertyName("timeGenerated")]
        public string? TimeGenerated { get; set; }
    }
}
