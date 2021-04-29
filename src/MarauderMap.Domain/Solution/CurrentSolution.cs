using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.DependencyInjection;

namespace MarauderMap.Solution
{
    public class CurrentSolution : ICurrentSolution, ISingletonDependency
    {

        public string Directory => Path.GetDirectoryName(FullPath);

        public string FullPath { get; private set; }

        public Task SetPathAsync(string fullPath)
        {
            Check.NotNullOrWhiteSpace(fullPath, nameof(fullPath));
            FullPath = fullPath;
            return Task.CompletedTask;
        }
    }
}
