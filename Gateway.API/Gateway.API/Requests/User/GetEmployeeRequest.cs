using Newtonsoft.Json;

namespace Gateway.API.Requests.User
{
    public class GetEmployeeRequest
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }
    }
}
