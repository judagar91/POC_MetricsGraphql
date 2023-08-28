namespace GraphQLAPI.DTOs
{
    public class SendsDTO
    {
        public string ?Event { get; set; }
        public string ?CultureCode { get; set; }
        public int ?TotalContacts { get; set; }
        public string ?Channel { get; set; }
        public string ?Success { get; set; }
        public DateTime CreatedDate { get; set;}
    }
}