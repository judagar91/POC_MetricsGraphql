using GraphQLAPI.Models;
using GraphQLAPI.Services;

namespace GraphQLAPI.App.Data
{
    public static class SendsFake
    {
        public static void EnsureSeedData(this SendsContext db)
        {
            if (!db.Sends.Any())
            {
                var sends = new List<Sends>
                {
                    new Sends
                    {
                        Event = "BookingUpdated",
                        Success = "Sent",
                        Channel = "sms",
                        CreatedDate = DateTime.Now,
                        CultureCode = "en-US",
                        TotalContacts = 1
                    },            
                    new Sends
                    {
                        Event = "Confirmed",
                        Success = "Failed",
                        Channel = "email",
                        CreatedDate = DateTime.Now,
                        CultureCode = "es-Es",
                        TotalContacts = 1
                    },
                };
            }
        }
    }
}
