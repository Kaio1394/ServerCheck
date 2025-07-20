using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ServerCheck.Models
{
    class Cpu
    {
        [JsonPropertyName("nameProcessor")]
        public string? NameProcessor { get; set; }
        [JsonPropertyName("frequency")]
        public float Frequency { get; set; }
        [JsonPropertyName("core")]
        public int Core { get; set; }
        [JsonPropertyName("usagePercent")]
        public double UsagePercent { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"************************** CPU **************************");
            sb.AppendLine($"    Name: {NameProcessor}");
            sb.AppendLine($"    Frequency: {Frequency} Hz");
            sb.AppendLine($"    Core: {Core}");
            sb.AppendLine($"    Usage: {UsagePercent:F2}%");
            return sb.ToString();
        }
    }
}
