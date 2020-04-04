using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundaClient
{
    class Program
    {
        public static async System.Threading.Tasks.Task Main(string[] args)
        {
            //BuildWebHost(args).Run();
            try
            {
                ApplicationSettings.WebApiUrl = "http://partnerapi.funda.nl/feeds/Aanbod.svc/json/ac1b0b1572524640a0ecc54de453ea9f/";
                var result = await ApiClientFactory.Instance.GetPropertyListing(1);
                var totalPages = result.Paging.TotalPages;
                Console.WriteLine($"Total listings: {result.Total}");
                Console.WriteLine($"TotalPages: {totalPages}");
                var agents = new List<AgentModel>();
                agents.AddRange(result.Listings.Select(x => new AgentModel { Id = x.AgentId, Name = x.AgentName }));
                Console.WriteLine($"page: {1}");
                for (int page = 2; page <= totalPages; page++)
                {
                    Task.Delay(1000).Wait();
                    result = await ApiClientFactory.Instance.GetPropertyListing(page);
                    agents.AddRange(result.Listings.Select(x => new AgentModel { Id = x.AgentId, Name = x.AgentName }));
                    Console.WriteLine($"page: {page}");
                }

                var groupedAgents = agents.GroupBy(a => a.Id)
                    .Select(x => new
                    {
                        AgentId = x.Key,
                        AgentName = agents.First(y => y.Id == x.Key).Name,
                        Count = x.Count()
                    })
                    .OrderByDescending(x => x.Count);

                groupedAgents.Take(10).ToList().ForEach(agent => Console.WriteLine("{0}  {1}", agent.AgentName, agent.Count));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
