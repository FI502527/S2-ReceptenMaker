using Interfaces;

namespace Recipe_Maker
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Other service registrations...

            services.AddScoped<IUserRepository>();

            // Additional registrations...
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure middleware and other components...
        }
    }
}
