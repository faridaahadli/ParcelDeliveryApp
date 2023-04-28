using Gateway.API.Models;
using Newtonsoft.Json;

namespace Gateway.API.Requests.User
{
    public class GetEmployeesRequest
    {
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }=new Pagination();
    }
}
