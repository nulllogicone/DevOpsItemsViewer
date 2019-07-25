# Azure DevOps WorkItems Viewer

> Shows prviate workitems from a query on a public website

If you want to show Azure DevOps items to other people without access.
This is the most minimal prototype, it was fun, like finger practice.

[Deploy to Azure button!]  

The site is *public* so be aware what you can do next:
Create a new Query in your Azure DevOps that is really limited to all items that can be publicly shown to anonymous people. 
Use tags for example and only filter to items 'Created by you'.
Then copy the Guid from the query url in Azure DevOps and append it to my app service url above.  

I would say it's secure enough for now. Nobody can iterate over Guids, 
those who know the guids and share them are aware what they do, i
f something should be revoked it's easy to delete the query 
(and create the same with new guid) and the app can always be stopped or deleted. 
But of course we could add AAD authentication if needed.
