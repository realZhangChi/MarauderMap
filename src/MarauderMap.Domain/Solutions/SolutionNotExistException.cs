using Volo.Abp;

namespace MarauderMap.Solutions
{
    public class SolutionNotExistException : UserFriendlyException
    {
        public SolutionNotExistException()
        : base("Solution does not exist!")
        {

        }
    }
}
