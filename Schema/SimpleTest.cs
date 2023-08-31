﻿using GraphQLAPI.App.Models;
using HotChocolate.Execution;
using Snapshooter.Xunit;
using Xunit;

namespace GraphQLAPI.Schema
{
    public class SimpleTest
    {
        [Fact]
        public async Task SchemaChangeTest()
        {
            var schema = await new ServiceCollection()
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .BuildSchemaAsync();

            schema.ToString().MatchSnapshot();
        }
    }
}
