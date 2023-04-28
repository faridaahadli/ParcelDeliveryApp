using Newtonsoft.Json;

namespace Gateway.API.Requests.OrderDelivery
{
    public class CreateOrderRequest
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("deliveryTypeId")]
        public int DeliveryTypeId { get; set; }
        [JsonProperty("authorId")]
        public int AuthorId { get; set; }
    }
}
