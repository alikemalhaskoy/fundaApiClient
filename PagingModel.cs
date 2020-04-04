using System.Runtime.Serialization;

namespace FundaClient
{
    [DataContract]
    public class PagingModel
    {
        [DataMember(Name = "AantalPaginas")]
        public int TotalPages { get; set; }

        [DataMember(Name = "HuidigePagina")]
        public int CurrentPage { get; set; }
    }

}
