using System.Collections.Generic;

namespace MarauderMap.Solutions
{
    public class TreeNodeDto
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public bool IsFile { get; set; }

        public ICollection<TreeNodeDto> Children { get; set; }
        
    }
}
