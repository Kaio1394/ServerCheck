using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ServerCheck.Models
{
    class Memory
    {
        [JsonPropertyName("total")]
        public decimal Total { get; set; }

        [JsonPropertyName("free")]
        public decimal Free { get; set; }

        [JsonPropertyName("usage")]
        public decimal Usage { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"************************** MEMORY **************************");
            sb.AppendLine($"    Usage: {Usage}");
            sb.AppendLine($"    Free: {Free}");
            sb.AppendLine($"    Total: {Total}");
            return sb.ToString();
        }
    }
}
