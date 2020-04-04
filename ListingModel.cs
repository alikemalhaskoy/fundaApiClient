using System.Runtime.Serialization;

namespace FundaClient
{
    [DataContract]
    public class ListingModel
    {
        [DataMember(Name = "Id")]
        public string Id { get; set; }

        [DataMember(Name = "MakelaarId")]
        public string AgentId { get; set; }

        [DataMember(Name = "MakelaarNaam")]
        public string AgentName { get; set; }
    }

}
