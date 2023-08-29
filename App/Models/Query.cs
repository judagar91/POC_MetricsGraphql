using GraphQLAPI.DTOs;
using GraphQLAPI.Models;
using GraphQLAPI.Repository;
using GraphQLAPI.Services;
using Microsoft.Extensions.Logging;
using System.Threading.Channels;

namespace GraphQLAPI.App.Models
{
    public class Query
    {
        //private readonly SendsRespository _sendsRepository;

        //public Query(SendsRespository _sendsRepository)
        //{
        //    this._sendsRepository = _sendsRepository ?? throw new ArgumentNullException(nameof(_sendsRepository));
        //}
        //public async Task<IEnumerable<Sends>> GetEvents()
        //{
        //    IEnumerable<SendsDTO> sendsDTO = await _sendsRepository.GetAll();

        //    return sendsDTO.Select(c => new Sends()
        //    {
        //        Event = c.Event,
        //        CultureCode = c.CultureCode,
        //        TotalContacts = c.TotalContacts,
        //        Channel = c.Channel,
        //        Success = c.Success,
        //        CreatedDate = c.CreatedDate
        //    });
        //}
        //public async Task<IEnumerable<Sends>> GetEventsbyChannel(string channel, string success)
        //{
        //    IEnumerable<SendsDTO> sendsDTOs = await _sendsRepository.GetAll();
        //    return sendsDTOs.Select(c => new Sends()
        //    {
        //        Event = c.Event,
        //        CultureCode = c.CultureCode,
        //        TotalContacts = c.TotalContacts,
        //        Channel = c.Channel,
        //        Success = c.Success,
        //        CreatedDate = c.CreatedDate
        //    }).Where(c => c.Channel == channel && c.Success == success);
        //}

        [UseDbContext(typeof(SendsContext))]
        [UsePaging(IncludeTotalCount = true, DefaultPageSize = 10)]
        [UseFiltering]
        public IQueryable<Sends> GetPaginatedSends([ScopedService] SendsContext context)
        {
            return context.Sends.Select(c => new Sends()
            {
                Event = c.Event,
                CultureCode = c.CultureCode,
                Channel = c.Channel,
                TotalContacts = c.TotalContacts,
                Success = c.Success,
                CreatedDate = c.CreatedDate
            });
        }
    }
}