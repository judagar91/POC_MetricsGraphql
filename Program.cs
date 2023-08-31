using GraphQLAPI.App.Models;
using GraphQLAPI.App.Schema;
using GraphQLAPI.Services;
using HotChocolate.Execution;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services
//    .AddGraphQLServer()
//    .AddQueryType<Query>()
//    .AddFiltering();
//.BuildSchemaAsync();

builder.Services.AddGraphQLServer().AddQueryType<Query>().AddTypeModule(_ => new UserSettingsTypeModule("./Models/Settings.json"));
var provider = builder.Services.BuildServiceProvider();
var _configuration = provider.GetRequiredService<IConfiguration>();
var connectionString = _configuration.GetConnectionString("default"); 
builder.Services.AddDbContextFactory<SendsContext>(o => o.UseSqlServer(connectionString));

var app = builder.Build();
app.MapGraphQL();
app.Run();