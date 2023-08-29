using GraphQLAPI.DTOs;
using GraphQLAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace GraphQLAPI.Repository
{
    public class SendsRespository
    {
        
        //private readonly IDbContextFactory<SendsContext> _dbContextFactory;
        //public SendsRespository(IDbContextFactory<SendsContext> dbContextFactory)
        //{
        //    _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
        //}

        //public async Task<IEnumerable<SendsDTO>> GetAll()
        //{

        //    using (SendsContext context = _dbContextFactory.CreateDbContext())
        //    {
        //        return await context.Sends.ToListAsync();
        //    }
        //}

        //public IEnumerable<Domain.Customer.Models.Customer> Get(Filter filter)
        //{
 

        //        if (filter is CustomerFilter) _dataEncrypter.Encrypt(filter as CustomerFilter);

        //        var contextQuery = _customerContext.Customers.AsNoTracking().BuildPredicate(filter);
        //        var customers = _mapper.ProjectTo<Domain.Customer.Models.Customer>(contextQuery).ToList();

        //        foreach (var customer in customers) _dataEncrypter.Decrypt(customer.PersonalInfo);


        //        return customers;
  

        //}
    }
}
