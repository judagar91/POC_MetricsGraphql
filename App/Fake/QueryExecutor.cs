using GraphQLAPI.App.Models;
using GraphQLAPI.Services;
using HotChocolate.Execution;
using HotChocolate.Execution.Configuration;
using Microsoft.EntityFrameworkCore;

namespace GraphQLAPI.App.Fake
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryExecutor(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public void Get(string foo)
        {
            try
            {

                var serviceCollection = new ServiceCollection();
                var executor = serviceCollection.AddGraphQLServer()
                        .AddQueryType<Query>()
                        .AddFiltering()
                        
                                 .BuildRequestExecutorAsync();
          
                serviceCollection.AddDbContextFactory<SendsContext>(o => o.UseSqlServer("Server=JUANGARCIA-NEWS\\SQLEXPRESS;Database=wl_message_dev;Trusted_Connection=True;TrustServerCertificate=true"));
                var build = executor.Result.ExecuteAsync(foo);
            }
            catch (Exception ex)
            {

                throw;
            }
  
        }
    }
}
