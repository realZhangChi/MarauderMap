using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using Volo.Abp;

namespace MarauderMap.Solutions
{
    public class TreeNode
    {
        public string Name => System.IO.Path.GetFileName(Path);

        public string Path { get; init; }

        public bool IsFile { get; init; }

        public ICollection<TreeNode> Children { get; }

        public TreeNode()
        {
            Children = new List<TreeNode>();
        }

        public TreeNode(
            [NotNull] string fullPath) : this()
        {
            Check.NotNullOrWhiteSpace(fullPath, nameof(fullPath));
            Path = fullPath;
            var fileAttributes = File.GetAttributes(fullPath);

            IsFile = (fileAttributes & FileAttributes.Directory) == 0;
        }
    }
}
