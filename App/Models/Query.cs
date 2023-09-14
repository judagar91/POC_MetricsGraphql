using GraphQLAPI.Models;
using GraphQLAPI.Services;
using System.Net.NetworkInformation;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;

namespace GraphQLAPI.App.Models
{
    public class Query
    {
        [UseDbContext(typeof(SendsContext))]
        public async Task<IQueryable<Sends>> GetEvents([ScopedService] SendsContext context)
        {
            IQueryable<Sends> sends = context.Sends.Select(c => new Sends()
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
        [UseDbContext(typeof(SendsContext))]
        public async Task<IQueryable<Sends>> GetEventsbyChannel([ScopedService] SendsContext context, string channel, string success)
        {
            IQueryable<Sends> sends = context.Sends.Select(c => new Sends()
            {
                Event = c.Event,
                CultureCode = c.CultureCode,
                Channel = c.Channel,
                TotalContacts = c.TotalContacts,
                Success = c.Success,
                CreatedDate = c.CreatedDate
            }).Where(c => c.Channel == channel && c.Success == success);

            return sends;
        }

        [UseDbContext(typeof(SendsContext))]
        [UsePaging(IncludeTotalCount = true,  DefaultPageSize = 10)]
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

        [UseDbContext(typeof(SendsContext))]
        public async Task<IQueryable<EventsbyChannel>> GetMetrics([ScopedService] SendsContext context)
        {
            var query = from c in context.Sends
                        group c by c.Channel into grouped
                        select new EventsbyChannel
                        {
                            channel = grouped.Key,  // Obtener el valor de la clave del grupo (el canal)
                            cantidad = grouped.Count()  // Contar la cantidad de elementos en el grupo
                        };

            return query;
        }
    }
}