using Newtonsoft.Json;

namespace Gateway.API.Requests.OrderDelivery
{
    public class DeliveryTrackRequest
    {
        [JsonProperty("orderId")]
        public int OrderId { get; set; }
        [JsonProperty("longitude")]
        public double Longitude { get; set; }
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

    }
}
