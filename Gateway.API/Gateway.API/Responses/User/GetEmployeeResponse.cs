namespace Gateway.API.Responses.User
{
    public class GetEmployeeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
