using GraphQL.Types;
using GraphQLAPI.Models;

namespace GraphQLAPI.App.Models
{
    public class SendType : ObjectGraphType<Sends>
    {
        public SendType()
        {
            Field(x => x.Event);
            Field(x => x.Channel);
            Field(x => x.CultureCode);
            Field(x => x.Success);
            Field(x => x.CreatedDate);
            Field(x => x.TotalContacts);

        }
    }
}
