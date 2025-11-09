# Create Application Insights

## Step 1 - Create new resource

Go to Azure Portal (https://portal.azure.com) and create a new resource

![Create a new resource](03-01-create-new-resource.png)

## Step 2 - Search for "Application Insights"

![Search for Log Analytics Workspace](03-02-search-application-insights.png)

## Step 3 - Create "Application Insights"

### Basics

- **Subscription**
  - In my case I use the "Visual Studio Professional Subscription"
- **Resource group**
  - Choose the previously created `demo-rg`
- **Name**
  - `demo-appi`

- **Region**
  - Used the same region as the group: "West Europe".
- **Log Analytics Workspace**
  - Choose the previously created `demo-law`


![Properties - Basics](03-03-properties-basics.png)

## Tags

Add tags if necessary.

![Properties - Tags](03-04-properties-tags.png)

### Review + create

![Properties - Review](03-05-properties-review.png)

## Step 4 - Create

Click the "Create" button.

## Done

![Application Insights](03-06-application-insights.png)

**Note**

- One important information on this page is the "Connection string". This will be needed, later, in the C# application to connect to this specific Application insights resource.