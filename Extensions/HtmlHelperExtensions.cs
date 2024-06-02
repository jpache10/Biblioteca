using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Biblioteca.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static string IsActive(this IHtmlHelper htmlHelper, string controller, string action)
        {
            var routeData = htmlHelper.ViewContext.RouteData;
            var routeController = (routeData.Values["controller"] ?? "home").ToString();
            var routeAction = (routeData.Values["action"] ?? "index").ToString();

            return (controller == routeController && action == routeAction) ? "active" : "";
        }
    }
}
