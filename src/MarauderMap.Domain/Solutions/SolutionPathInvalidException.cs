using Volo.Abp;

namespace MarauderMap.Solutions
{
    public class SolutionPathInvalidException : UserFriendlyException
    {
        public SolutionPathInvalidException() : base(
            "The selected file is not a valid visual studio solution file(.sln)!")
        {
        }

    }
}
