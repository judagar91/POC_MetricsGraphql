﻿using GraphQLAPI.App.Models;
using GraphQLAPI.Models;

namespace GraphQLAPI.App.Fake
{
    public interface IQueryExecutor
    {
        Task Get(string foo);
    }
}