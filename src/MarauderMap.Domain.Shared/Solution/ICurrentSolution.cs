using System.Threading.Tasks;
using JetBrains.Annotations;

namespace MarauderMap.Solution
{
    public interface ICurrentSolution
    {
        public string Directory { get; }

        public string FullPath { get; }

        Task SetPathAsync([NotNull] string fullPath);
    }
}
