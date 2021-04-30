using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace MarauderMap.Solutions
{
    public interface ICurrentSolution
    {
        Solution Value { get; }

        internal Solution SetSolution(Solution value);
    }
}
