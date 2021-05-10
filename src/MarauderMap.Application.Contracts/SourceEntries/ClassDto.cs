using System;
using System.Collections.Generic;
using System.Text;

namespace MarauderMap.SourceEntries
{
    public class ClassDto
    {
        public ICollection<string> Imports { get; set; }

        public string Namespace { get; set; }

        public string ProjectFullPath { get; set; }

        public string Directory { get; set; }

        public string Name { get; set; }

        public string BaseClass { get; set; }

        public ICollection<string> BaseInterfaces { get; set; }

        public ICollection<PropertyDto> Properties { get; set; }

        protected ClassDto()
        {
            BaseInterfaces = new List<string>();
            Properties = new List<PropertyDto>();
            Imports = new List<string>();
        }
    }
}
