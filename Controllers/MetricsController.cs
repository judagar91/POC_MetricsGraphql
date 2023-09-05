﻿using GraphQLAPI.App.Fake;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetricsController : ControllerBase
    {
        private readonly IQueryExecutor _queryExecutor;

        public MetricsController(IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor ?? throw new ArgumentNullException(nameof(queryExecutor));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string query)
        {
            if (query == null)
            {
                return BadRequest();
            }
            else
            {
                var foo = query.ToString();
                _queryExecutor.Get(foo);
                return Ok();
            }
        }
    }
}