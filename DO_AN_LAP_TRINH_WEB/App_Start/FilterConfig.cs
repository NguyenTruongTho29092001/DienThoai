using System.Web;
using System.Web.Mvc;

namespace DO_AN_LAP_TRINH_WEB
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
