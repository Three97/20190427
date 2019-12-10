namespace Fms.Jpf.Submission.API
{
    using Fms.Jpf.Submission.DAL.Contracts;
    using Fms.Jpf.Submission.DAL.Implementations;
    using Fms.Jpf.Submission.Service;
    using Fms.Jpf.Submission.Service.Contracts;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        private readonly string _devOrigins = "DevOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Allow CORS for local Angular app (on port 4200)
            services.AddCors(opts =>
            {
                opts.AddPolicy(_devOrigins,
                    builder => { builder.WithOrigins("http://localhost:4200"); }
                );
            });

            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<ILocationRepository, FakeLocationRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(_devOrigins);

            app.UseMvc();
        }
    }
}
