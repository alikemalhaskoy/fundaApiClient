using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FundaClient
{
    [DataContract]
    public class FundaApiResponse
    {
        [DataMember(Name = "Objects")]
        public List<ListingModel> Listings{ get; set; }

        [DataMember(Name = "Paging")]
        public PagingModel Paging { get; set; }

        [DataMember(Name = "TotaalAantalObjecten")]
        public int Total { get; set; }
    }
}
