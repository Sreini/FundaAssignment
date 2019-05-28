using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Funda.Business;
using Funda.Business.Interface;
using Funda.DataAccess;
using Funda.DataAccess.Interface;
using FundaApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using static FundaApi.AanbodClient;

namespace Funda.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddTransient<IAanbod, AanbodClient>(ctx => new AanbodClient(EndpointConfiguration.wshttp));
            services.AddTransient<IAanbodService, AanbodService>();
            services.AddTransient<IMakelaarInfo, MakelaarInfo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
