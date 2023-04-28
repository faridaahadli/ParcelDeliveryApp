
namespace Gateway.API.Responses.OrderDelivery
{
    public class GetDeliveryResponse
    {
        public int CourierId { get; set; }
        public DateTime? ArriveDate { get; set; }
        public string? Comment { get; set; }
        public bool IsSuccess { get; set; }
    }
}