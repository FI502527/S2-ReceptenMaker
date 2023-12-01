using DAL;

namespace Recipe_Maker
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Other service registrations...

            services.AddScoped<UserRepository>();

            // Additional registrations...
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure middleware and other components...
        }
    }
}
