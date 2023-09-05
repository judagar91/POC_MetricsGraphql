using GraphQL;
using GraphQL.Types;
using GraphQLAPI.App.Models;
using GraphQLAPI.Repository;
using GraphQLAPI.Repository.Impl;
using GraphQLAPI.Schema;
using GraphQLAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var provider = builder.Services.BuildServiceProvider();

builder.Services.AddTransient<ISendRepository, SendRepository>();
var _configuration = provider.GetRequiredService<IConfiguration>();
var connectionString = _configuration.GetConnectionString("default"); 

builder.Services.AddDbContextFactory<SendsContext>(o => o.UseSqlServer(connectionString));
builder.Services.AddScoped<IDocumentExecuter, DocumentExecuter>();
builder.Services.AddScoped<Query>();
builder.Services.AddScoped<SendType>();
builder.Services.AddScoped<ISchema, SendsSchema>();




var app = builder.Build();
app.UseGraphQLGraphiQL();
app.Run();