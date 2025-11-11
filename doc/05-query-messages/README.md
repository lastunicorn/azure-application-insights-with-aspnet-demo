# Query Messages in Azure Portal

## Step 1 - Open Application Insights

In the web browser, open `https://portal.azure.com` and search for your Application Insights resource. In this example it is `demo-appi`:

![Open Application Insights](01-open-application-insights.png)

## Step 2 - Open "Logs" page

![Logs Page](02-logs-page.png)

## Step 3 - Query for requests

Each time an API endpoint is called, a record is added into the `requests` table from Application Insights.

Use KQL language to interrogate the table:

![Query for requests](03-query-for-results.png)