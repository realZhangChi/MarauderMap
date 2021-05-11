using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;

namespace MarauderMap.Solutions
{
    public class CurrentSolution : ICurrentSolution, ISingletonDependency
    {
        private SolutionTree _value;
        SolutionTree ICurrentSolution.Value => _value;

        SolutionTree ICurrentSolution.SetSolution(SolutionTree value)
        {
            _value = value;
            return _value;
        }
    }
}
