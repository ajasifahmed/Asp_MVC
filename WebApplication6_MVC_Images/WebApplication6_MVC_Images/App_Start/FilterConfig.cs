using System.Web;
using System.Web.Mvc;

namespace WebApplication6_MVC_Images
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
