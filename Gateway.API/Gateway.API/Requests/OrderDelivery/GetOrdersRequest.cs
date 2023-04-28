using Gateway.API.Models;
using Newtonsoft.Json;

namespace Gateway.API.Requests.OrderDelivery
{
    public class GetOrdersRequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }=new Pagination();
    }
}
