using GraphQLAPI.App.Models;
using GraphQLAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddFiltering();

//builder.Services.AddScoped<SendsRespository>();
var provider = builder.Services.BuildServiceProvider();
var _configuration = provider.GetRequiredService<IConfiguration>();
var connectionString = _configuration.GetConnectionString("default"); 
builder.Services.AddDbContextFactory<SendsContext>(o => o.UseSqlServer(connectionString));

var app = builder.Build();
app.MapGraphQL();
app.Run();