using System.Web;
using System.Web.Mvc;
using IXL.Core;

namespace IXL
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ElmahHandleErrorAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
