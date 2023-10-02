using Microsoft.Extensions.Configuration;
using Payment.Application.Interface;

namespace Payment.API.Services
{
    public class ConnectionService : IConnectionService
    {
        private readonly IConfiguration configuration;
        public ConnectionService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string Database => configuration.GetConnectionString("Database");
    }
}
