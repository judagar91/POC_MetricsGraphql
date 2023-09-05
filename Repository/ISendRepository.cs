using GraphQLAPI.Models;

namespace GraphQLAPI.Repository
{
    public interface ISendRepository
    {
        IQueryable<Sends> GetAll();
    }
}
