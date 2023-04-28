using Newtonsoft.Json;

namespace Gateway.API.Requests.OrderDelivery
{
    public class UpdateOrderByStaffRequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("userId")]
        public int UserId { get; set; }
        [JsonProperty("status")]
        public int Status { get; set; }
    }
}
