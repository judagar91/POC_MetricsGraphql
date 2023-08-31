using GraphQLAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLAPI.Context
{
    public class AccountContext : DbContext
    {
        public AccountContext() { }
        public DbSet<User> Users => Set<User>();
    }
}