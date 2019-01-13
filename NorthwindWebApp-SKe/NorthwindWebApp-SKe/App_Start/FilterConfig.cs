using System.Web;
using System.Web.Mvc;

namespace NorthwindWebApp_SKe
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
