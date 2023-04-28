using Newtonsoft.Json;

namespace Gateway.API.Requests.OrderDelivery
{
    public class UpdateOrderByUserRequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("userId")]
        public int UserId { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("isCanceled")]
        public bool IsCanceled { get; set; }
    }
}
