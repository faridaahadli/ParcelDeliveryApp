using Newtonsoft.Json;

namespace Gateway.API.Requests.OrderDelivery
{
    public class CreateDeliveryRequest
    {
        [JsonProperty("courierId")]
        public int CourierId { get; set; }
        [JsonProperty("comment")]
        public string? Comment { get; set; }
        [JsonProperty("orderId")]
        public int OrderId { get; set; }
    }
}
