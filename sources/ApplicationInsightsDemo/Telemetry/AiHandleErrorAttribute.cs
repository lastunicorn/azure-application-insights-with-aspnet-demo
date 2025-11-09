using System;
using System.Web.Mvc;
using Microsoft.ApplicationInsights;

namespace DustInTheWind.ApplicationInsightsDemo.Telemetry
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class AiHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext != null && filterContext.HttpContext != null && filterContext.Exception != null)
            {
                //If customError is Off, then AI HTTPModule will report the exception
                if (filterContext.HttpContext.IsCustomErrorEnabled)
                {
                    TelemetryClient telemetryClient = new TelemetryClient();
                    telemetryClient.TrackException(filterContext.Exception);
                }
            }
            base.OnException(filterContext);
        }
    }
}