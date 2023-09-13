using GraphQLAPI.App.Models;
using GraphQLAPI.Services;
using HotChocolate.Execution;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json;

namespace GraphQLAPI.App.Fake
{
    public class QueryExecutor : IQueryExecutor
    {
        public QueryExecutor()
        {
            
        }

        public async Task<string> Get(string foo)
        {
            try
            {
                
                var serviceCollection = new ServiceCollection();
                serviceCollection.AddPooledDbContextFactory<SendsContext>(x => x.UseSqlServer("Server=JUANGARCIA-NEWS\\SQLEXPRESS;Database=wl_message_dev;Trusted_Connection=True;TrustServerCertificate=true"));
                var executor = serviceCollection
                        .AddGraphQLServer()
                        .AddQueryType<Query>()
                        .RegisterDbContext<SendsContext>(DbContextKind.Pooled)
                        .AddFiltering()
                        .BuildRequestExecutorAsync();

                //ConfigureServices(serviceCollection);
                var build = await executor.Result.ExecuteAsync(foo);

                var result = build.ExpectQueryResult().Data.AsEnumerable();

                return JsonConvert.SerializeObject(result).ToString();


            }
            catch (Exception ex)
            {

                throw;
                
            }

  
        }
    }
}
