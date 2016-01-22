using System.Web;
using System.Web.Mvc;

namespace MarkdownManager
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            // prevents anonymous users from access any methods ... AllowAnonymous to allow on methods
            filters.Add(new System.Web.Mvc.AuthorizeAttribute());
            // require all access to be through https
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
