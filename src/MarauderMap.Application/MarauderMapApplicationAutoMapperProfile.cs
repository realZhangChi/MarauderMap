using AutoMapper;
using MarauderMap.Solutions;

namespace MarauderMap
{
    public class MarauderMapApplicationAutoMapperProfile : Profile
    {
        public MarauderMapApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<TreeNode, TreeNodeDto>();
            CreateMap<SolutionTree, SolutionDto>();
        }
    }
}
