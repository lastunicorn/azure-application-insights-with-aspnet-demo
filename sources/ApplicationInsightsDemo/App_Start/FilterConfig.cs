using System.Web.Mvc;
using DustInTheWind.ApplicationInsightsDemo.Telemetry;

namespace DustInTheWind.ApplicationInsightsDemo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new AiHandleErrorAttribute());
        }
    }
}
