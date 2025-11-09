# Azure Application Insights with ASP.NET Tutorial

## Step 1 - Install NuGet packages

```
Install-Package Microsoft.ApplicationInsights.WindowsServer
Install-Package Microsoft.ApplicationInsights.Web
Install-Package Microsoft.AspNet.TelemetryCorrelation
```

## Step 2 - Create the configuration file

Create the `ApplicationInsights.config`  file:

- (see the example file from the current directory)

## Step 3 - Add connection string

You can find the connection string on the overview pane of the Application Insights resource in Azure Portal.

The connection string can be added in config file or in C# code.

### a) In config file

In the `ApplicationInsights.config` created earlier add this element:

```xml
<ConnectionString>Copy the connection string from your Application Insights resource</ConnectionString>
```

### b) In C#

The connection string must be provided to the `TelemetryConfiguration` instance:

```csharp
TelemetryConfiguration configuration = new TelemetryConfiguration()
{
    ConnectionString = "Copy the connection string from your Application Insights resource"
};
```

## Step 4 - Log errors

### 1) Create a filter class

Create a filter class derived from `HandleErrorAttribute` that will be called for an exception:

```csharp
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
```

### 2) Add the filter globally

In the existing `FilterConfig` class from `App_Start` directory, replace the existing instance of the `HandleErrorAttribute` with the newly created `AiHandleErrorAttribute`:

```csharp
public class FilterConfig
{
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
        filters.Add(new AiHandleErrorAttribute());
    }
}
```

## Step 5 - Update `Web.cofig` file

### 1) Add HTTP modules in `<system.web>`

In `<system.web>` element add the following HTTP modules:

- `TelemetryCorrelationHttpModule`
- `ApplicationInsightsWebTracking`

```xml
<configuration>
    ...

    <system.web>
        ...

        <httpModules>
            <add name="TelemetryCorrelationHttpModule" type="Microsoft.AspNet.TelemetryCorrelation.TelemetryCorrelationHttpModule, Microsoft.AspNet.TelemetryCorrelation" />
            <add name="ApplicationInsightsWebTracking" type="Microsoft.ApplicationInsights.Web.ApplicationInsightsHttpModule, Microsoft.AI.Web" />
        </httpModules>
        
    </system.web>
</configuration>
```

### 2) Add HTTP modules in `<system.webServer>`

Add the same modules in the `<system.webServer>` element:

- `TelemetryCorrelationHttpModule`
- `ApplicationInsightsWebTracking`

```xml
<configuration>
    ...

    <system.webServer>
        ...

        <modules>
            <remove name="TelemetryCorrelationHttpModule" />
            <add name="TelemetryCorrelationHttpModule" type="Microsoft.AspNet.TelemetryCorrelation.TelemetryCorrelationHttpModule, Microsoft.AspNet.TelemetryCorrelation" preCondition="managedHandler" />
            <remove name="ApplicationInsightsWebTracking" />
            <add name="ApplicationInsightsWebTracking" type="Microsoft.ApplicationInsights.Web.ApplicationInsightsHttpModule, Microsoft.AI.Web" preCondition="managedHandler" />
        </modules>
        
    </system.webServer>
</configuration>
```



## References

- https://learn.microsoft.com/en-us/azure/azure-monitor/app/dotnet?tabs=net%2Cnet-1%2Cserver%2Cportal%2Ccsharp%2Cprocess%2Capi-net