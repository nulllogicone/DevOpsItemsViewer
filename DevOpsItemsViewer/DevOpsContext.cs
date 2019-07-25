using Microsoft.Extensions.Configuration;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.Identity;
using Microsoft.VisualStudio.Services.WebApi;
using Microsoft.VisualStudio.Services.WebApi.Patch;
using Microsoft.VisualStudio.Services.WebApi.Patch.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Threading.Tasks;

namespace DevOpsItemsViewer
{
    public class DevOpsContext
    {

        readonly WorkItemTrackingHttpClient witClient;

        public DevOpsContext(string devOpsUrl, string accessToken)
        {
            var connection = new VssConnection(new Uri(devOpsUrl), new VssBasicCredential(string.Empty, accessToken));
            witClient = connection.GetClient<WorkItemTrackingHttpClient>();
        }

        public async Task<IEnumerable<WorkItem>> GetWorkItemsAsync(IEnumerable<int> ids)
        {
            var result = await witClient.GetWorkItemsAsync(ids);
            return result;
        }

        public async Task<IEnumerable<WorkItemReference>> GetWorkItemReferencesByQueryGuidAsync(Guid queryGuid)
        {
            var result = await witClient.QueryByIdAsync(queryGuid);
            return result.WorkItems;
        }
    }
}
