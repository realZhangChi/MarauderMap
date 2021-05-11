using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace MarauderMap.Solutions
{
    public class Project : Entity<Guid>
    {
        public virtual Guid SolutionId { get; set; }

        [Required]
        [MaxLength(SolutionConsts.PathMaxLength)]
        public virtual string AbsolutePath { get; private set; }

        [NotMapped]
        public virtual string Name => Path.GetFileNameWithoutExtension(AbsolutePath);

        public virtual Solution Solution { get; set; }

        protected Project()
        {

        }
    }
}
