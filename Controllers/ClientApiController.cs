using CoreApiModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundaClient.Controllers
{
    public class AgentsController : ApiControllerBase
    {
        public AgentsController(IOptions<ApiSettingsModel> appSettings)
        {
            ApplicationSettings.WebApiUrl = appSettings.Value.WebApiBaseUrl;
        }

        [HttpGet]
        public async Task<IActionResult> GetTopAgents(string type, string filter)
        {
            var result = await ApiClientFactory.Instance.GetPropertyListing(1, type, filter);
            var totalPages = result.Paging.TotalPages;
            var agents = new List<AgentModel>();
            agents.AddRange(result.Listings.Select(x => new AgentModel { Id = x.AgentId, Name = x.AgentName }));

            for (int page = 2; page <= totalPages; page++)
            {
                Task.Delay(1000).Wait();
                result = await ApiClientFactory.Instance.GetPropertyListing(page, type, filter);
                agents.AddRange(result.Listings.Select(x => new AgentModel { Id = x.AgentId, Name = x.AgentName }));
            }

            var groupedAgents = agents.GroupBy(a => a.Id)
                .Select(x => new
                {
                    AgentId = x.Key,
                    AgentName = agents.First(y => y.Id == x.Key).Name,
                    Count = x.Count()
                })
                .OrderByDescending(x => x.Count);

            return Ok(groupedAgents.Take(10).ToList());
        }
    }
}
