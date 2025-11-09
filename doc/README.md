# Azure Application Insights with ASP.NET Tutorial

To use Azure Application Insights within an ASP.NET Web API application the following steps are needed:

1. [Create a Resource Group resource](01-create-resource-group.md)
  - Created from Azure Portal
  - In this group will create other Azure resources.

2. [Create a Log Analytical Workspace](02-create-log-analytics-workspace.md)
  - Created from Azure Portal

  - An application Insights resource must be linked to a Log Analytical Workspace

3. [Create an Application Insights resource](03-create-application-insights.md)
  - Created from Azure Portal

4. [Connect to the Application Insights](01-configure-application-insights.md)
  - Create an ASP.NET Web API application
  - Configure the application to connect to the Application Insights

5. [Query Application Insights](02-query-messages.md)
  - From Azure Portal
  - Use KQL queries in Application Insights to obtain telemetry information


## References

- https://learn.microsoft.com/en-us/azure/azure-monitor/app/dotnet?tabs=net%2Cnet-1%2Cserver%2Cportal%2Ccsharp%2Cenqueue%2Capi-net

