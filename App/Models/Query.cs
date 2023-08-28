using GraphQLAPI.DTOs;
using GraphQLAPI.Models;
using GraphQLAPI.Repository;

namespace GraphQLAPI.App.Models
{
    public class Query
    {
        private readonly SendsRespository _MSG_Repository;

        public Query(SendsRespository _sendsRepository)
        {
            _MSG_Repository = _sendsRepository ?? throw new ArgumentNullException(nameof(_sendsRepository));
        }
        public async Task<IEnumerable<Sends>> GetEvents()
        {
            IEnumerable<SendsDTO> sendsDTO = await _MSG_Repository.GetAll();

            return sendsDTO.Select(c => new Sends()
            {
                Event = c.Event,
                CultureCode = c.CultureCode,
                TotalContacts = c.TotalContacts,
                Channel = c.Channel,
                Success = c.Success,
                CreatedDate = c.CreatedDate
            });
        }
    }
}