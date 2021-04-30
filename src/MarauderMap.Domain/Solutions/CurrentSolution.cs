using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;

namespace MarauderMap.Solutions
{
    public class CurrentSolution : ICurrentSolution, ISingletonDependency
    {
        private Solution _value;
        Solution ICurrentSolution.Value => _value;

        Solution ICurrentSolution.SetSolution(Solution value)
        {
            _value = value;
            return _value;
        }
    }
}
