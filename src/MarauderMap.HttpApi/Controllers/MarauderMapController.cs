using MarauderMap.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace MarauderMap.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class MarauderMapController : AbpController
    {
        protected MarauderMapController()
        {
            LocalizationResource = typeof(MarauderMapResource);
        }
    }
}