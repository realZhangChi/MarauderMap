using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarauderMap.SourceEntries
{
    public class PropertyEntry
    {
        public string AccessLevel { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public string GetAccessLevel { get; set; }

        public string SetAccessLevel { get; set; }
    }
}
