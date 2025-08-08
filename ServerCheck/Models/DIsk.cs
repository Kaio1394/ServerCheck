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
    public class Disk
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("info")]
        public DictionaryInfoDisk? Info { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"************************** DISK **************************");
            sb.AppendLine($"    Disk Name: {Name}");
            sb.AppendLine($"    Info:");
            sb.AppendLine($"    - Total: {Info.TotalSpace} GB");
            sb.AppendLine($"    - Usage: {Info.UsedSpace} GB");
            sb.AppendLine($"    - Free: {Info.FreeSpace} GB");
            return sb.ToString();
        }
    }
    [ExcludeFromCodeCoverage]
    public class DictionaryInfoDisk
    {
        [JsonPropertyName("totalSpace")]
        public long TotalSpace { get; set; }
        [JsonPropertyName("usedSpace")]
        public long UsedSpace { get; set; }
        [JsonPropertyName("freeSpace")]
        public long FreeSpace { get; set; }
    }
}
