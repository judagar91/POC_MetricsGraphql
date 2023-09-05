using GraphQL.Types;
using GraphQLAPI.Repository;

namespace GraphQLAPI.App.Models
{
    public class Query : ObjectGraphType
    {
        public Query(ISendRepository sendRepository)
        {
            Field<ListGraphType<SendType>>(
                "Sends",
                resolve: context => sendRepository.GetAll());

        }
        //public async Task<IQueryable<Sends>> GetEvents([ScopedService] SendsContext context)
        //{
        //    IQueryable<Sends> sends = context.Sends.Select(c => new Sends()
        //    {
        //        Event = c.Event,
        //        CultureCode = c.CultureCode,
        //        Channel = c.Channel,
        //        TotalContacts = c.TotalContacts,
        //        Success = c.Success,
        //        CreatedDate = c.CreatedDate
        //    });

        //    return sends;
        //}
        //[UseDbContext(typeof(SendsContext))]
        //public async Task<IQueryable<Sends>> GetEventsbyChannel([ScopedService] SendsContext context, string channel, string success)
        //{
        //    IQueryable<Sends> sends = context.Sends.Select(c => new Sends()
        //    {
        //        Event = c.Event,
        //        CultureCode = c.CultureCode,
        //        Channel = c.Channel,
        //        TotalContacts = c.TotalContacts,
        //        Success = c.Success,
        //        CreatedDate = c.CreatedDate
        //    }).Where(c => c.Channel == channel && c.Success == success);

        //    return sends;
        //}

        //[UseDbContext(typeof(SendsContext))]
        //[UsePaging(IncludeTotalCount = true, DefaultPageSize = 10)]
        //[UseFiltering]
        //public IQueryable<Sends> GetPaginatedSends([ScopedService] SendsContext context)
        //{
        //    return context.Sends.Select(c => new Sends()
        //    {
        //        Event = c.Event,
        //        CultureCode = c.CultureCode,
        //        Channel = c.Channel,
        //        TotalContacts = c.TotalContacts,
        //        Success = c.Success,
        //        CreatedDate = c.CreatedDate
        //    });
        //}
    }
}