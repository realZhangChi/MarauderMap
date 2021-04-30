using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Services;

namespace MarauderMap.Solutions
{
    public class SolutionManager : DomainService
    {
        private readonly string[] _foldersToIgnore = {
            "bin",
            "obj",
            "Properties"
        };

        protected ICurrentSolution CurrentSolution => LazyServiceProvider.LazyGetRequiredService<ICurrentSolution>();

        public Task<Solution> SetSolutionAsync([NotNull] string fullPath)
        {
            if (!fullPath.EndsWith(".sln"))
            {
                throw new SolutionPathInvalidException();
            }
            if (!File.Exists(fullPath))
            {
                throw new SolutionNotExistException();
            }
            // ReSharper disable once AssignNullToNotNullAttribute
            var root = new TreeNode(Path.GetDirectoryName(fullPath));
            SetChildren(root);
            var solution = new Solution(root);
            CurrentSolution.SetSolution(solution);
            return Task.FromResult(CurrentSolution.Value);
        }

        private void SetChildren(TreeNode node)
        {
            if (node.IsFile)
            {
                return;
            }

            var directories = Directory.GetDirectories(node.Path);
            foreach (var directory in directories)
            {
                var directoryName = Path.GetFileName(directory);
                if (directoryName.StartsWith('.') || _foldersToIgnore.Contains(directoryName))
                {
                    continue;
                }
                var directoryChild = new TreeNode(directory);
                SetChildren(directoryChild);
                node.Children.Add(directoryChild);
            }

            var files = Directory.GetFiles(node.Path);
            foreach (var file in files)
            {
                if (Path.GetFileName(file).StartsWith('.'))
                {
                    continue;
                }
                node.Children.Add(new TreeNode(file));
            }
        }
    }
}
