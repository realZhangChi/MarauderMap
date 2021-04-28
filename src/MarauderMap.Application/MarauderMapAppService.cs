using System;
using System.Collections.Generic;
using System.Text;
using MarauderMap.Localization;
using Volo.Abp.Application.Services;

namespace MarauderMap
{
    /* Inherit your application services from this class.
     */
    public abstract class MarauderMapAppService : ApplicationService
    {
        protected MarauderMapAppService()
        {
            LocalizationResource = typeof(MarauderMapResource);
        }
    }
}
