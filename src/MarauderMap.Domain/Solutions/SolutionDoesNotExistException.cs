using Volo.Abp;

namespace MarauderMap.Solutions
{
    public class SolutionDoesNotExistException : UserFriendlyException
    {
        public SolutionDoesNotExistException()
        : base("Solution does not exist!")
        {

        }
    }
}
