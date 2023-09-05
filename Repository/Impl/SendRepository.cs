using GraphQLAPI.Models;
using GraphQLAPI.Services;

namespace GraphQLAPI.Repository.Impl
{
    public class SendRepository : ISendRepository
    {
        private readonly SendsContext _sendsContext;

        public SendRepository(SendsContext sendsContext)
        {
            _sendsContext = sendsContext ?? throw new ArgumentNullException(nameof(sendsContext));
        }

        public IQueryable<Sends> GetAll()
        {

            IQueryable<Sends> sends = _sendsContext.Sends.Select(c => new Sends()
            {
                Event = c.Event,
                CultureCode = c.CultureCode,
                Channel = c.Channel,
                TotalContacts = c.TotalContacts,
                Success = c.Success,
                CreatedDate = c.CreatedDate
            });

            return sends;
        }
    }
}
