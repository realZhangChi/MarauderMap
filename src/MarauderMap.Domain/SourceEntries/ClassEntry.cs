using System.Collections.Generic;

namespace MarauderMap.SourceEntries
{
    public class ClassEntry
    {
        public ICollection<string> Imports { get; set; }

        public string Namespace { get; set; }

        public string ProjectFullPath { get; set; }

        public string Directory { get; set; }

        public string Name { get; set; }

        public string BaseClass { get; set; }

        public ICollection<string> BaseInterfaces { get; set; }

        public ICollection<PropertyEntry> Properties { get; set; }

        protected ClassEntry()
        {
            BaseInterfaces = new List<string>();
            Properties = new List<PropertyEntry>();
            Imports = new List<string>();
        }
    }
}
