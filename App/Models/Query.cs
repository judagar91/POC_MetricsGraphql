using GraphQLAPI.Models;

namespace GraphQLAPI.App
{
    public class Query
    {
        //[GraphQLDeprecated("This query is deprecated")]
        public Book GetBook() =>
            new Book
            {
                Title = "C# in depth.",
                Author = new Author
                {
                    Name = "Jon Skeet"
                },
                Cultures = new List<string>
                {
                    "ES","EN","FR"
                }
            };
    }
}