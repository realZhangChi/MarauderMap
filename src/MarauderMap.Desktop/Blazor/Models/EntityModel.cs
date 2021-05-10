using MarauderMap.SourceEntries;
using System.Collections.Generic;

namespace MarauderMap.Desktop.Blazor.Models
{
    public class EntityModel : ClassDto
    {
        public new IList<PropertyModel> Properties { get; set; }

        public EntityModel()
        {
            Properties = new List<PropertyModel>();
        }
    }
}
