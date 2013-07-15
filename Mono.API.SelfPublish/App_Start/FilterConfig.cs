using System.Web;
using System.Web.Mvc;

namespace Mono.API.SelfPublish
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}