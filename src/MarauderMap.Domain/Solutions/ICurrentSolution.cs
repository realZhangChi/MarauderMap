using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace MarauderMap.Solutions
{
    public interface ICurrentSolution
    {
        SolutionTree Value { get; }

        internal SolutionTree SetSolution(SolutionTree value);
    }
}
