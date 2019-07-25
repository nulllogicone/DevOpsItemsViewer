using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;

namespace DevOpsItemsViewer.Pages
{
    public class IndexModel : PageModel
    {
        readonly IConfiguration config;
        public string DevOpsUri { get; set; }
        public IEnumerable<WorkItem> WorkItems;

        public IndexModel(IConfiguration config)
        {
            this.config = config;
            DevOpsUri = config.GetValue<string>("DevOpsUrl");
        }

        public async Task OnGetAsync(Guid? queryGuid)
        {
            if (!queryGuid.HasValue) {
                ModelState.AddModelError("QueryGuid", "Please provide a query guid");
                return;
            }
            var devops = new DevOpsContext(
                DevOpsUri,
                config.GetValue<string>("DevOpsAccessToken"));
            var workItemRefs = await devops.GetWorkItemReferencesByQueryGuidAsync(queryGuid.Value);
            var ids = workItemRefs.Select(w => w.Id).ToArray().Take(20);
            WorkItems = await devops.GetWorkItemsAsync(ids);

            foreach (var wi in WorkItems)
            {
                try
                {
                    var t = wi.Fields["System.Description"];
                    var d = wi.Fields.GetValueOrDefault("System.Description");
                }
                catch (Exception)
                {
                    var tnf = wi;
                    //throw;
                }
            }
        }

        public string GetUrlToWorkItem(WorkItem wi) {
            return $"{DevOpsUri}/_workitems/edit/{wi.Id}";
        }
    }
}
