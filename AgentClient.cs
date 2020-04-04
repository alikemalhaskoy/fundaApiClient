using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FundaClient
{
    public partial class ApiClient
    {
        public async Task<FundaApiResponse> GetPropertyListing(int page)
        {
            var requestUrl = CreateRequestUri( "",string.Format(System.Globalization.CultureInfo.InvariantCulture,
                $"?type=koop&zo=/amsterdam/&page={page}&pagesize=25"));
            return await GetAsync<FundaApiResponse>(requestUrl);
        }
    }
}
