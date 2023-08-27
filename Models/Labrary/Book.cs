namespace GraphQLAPI.Models
{
    public class Book 
    {
        public string Title { get; set; }
        public Author Author { get; set; } 

        public IEnumerable<string> Cultures { get; set; }
    }
}