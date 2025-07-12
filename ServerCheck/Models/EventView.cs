using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCheck.Models
{
    [ExcludeFromCodeCoverage]
    public class EventView
    {
        public required string? EntryType { get; set; }
        public required string? Source { get; set; }
        public required string? Message { get; set; }
        public required string? TimeGenerated { get; set; }
    }
}
