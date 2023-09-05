using GraphQLAPI.App.Fake;
using GraphQLAPI.App.Models;
using GraphQLAPI.Services;
using HotChocolate.Execution;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddScoped<SendsRespository>();
//var provider = builder.Services.BuildServiceProvider();
//var _configuration = provider.GetRequiredService<IConfiguration>();
//var connectionString = _configuration.GetConnectionString("default"); 
//builder.Services.AddDbContextFactory<SendsContext>(o => o.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.Services.AddScoped<IQueryExecutor, QueryExecutor>();
//builder.Services
//    .AddGraphQLServer()
//    .AddQueryType<Query>()
//    .AddFiltering()
//    .RegisterService<IQueryExecutor>();





var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseRouting();
//app.MapGraphQL();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapGraphQL();
//});
app.Run();