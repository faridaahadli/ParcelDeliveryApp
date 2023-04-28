using Newtonsoft.Json;

namespace Gateway.API.Requests.OrderDelivery
{
    public class GetOrderRequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
