namespace Gateway.API.Responses.OrderDelivery
{
    public class GetOrderResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }
        public GetDeliveryTypeResponse DeliveryType { get; set; }
        public int AuthorId { get; set; }
        public virtual ICollection<GetDeliveryResponse> Deliveries { get; set; } = new List<GetDeliveryResponse>();
    }
}
