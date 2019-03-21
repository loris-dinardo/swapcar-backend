using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swapcar.GraphQL.Core.Extensions;
using Swapcar.GraphQL.Dicos.Extensions;

namespace Swapcar.GraphQL
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        private readonly IHostingEnvironment HostingEnv;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            HostingEnv = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                // CORE EXTENSIONS
                .AddCoreDatabaseConfiguration(Configuration)
                .AddCoreGraphQLConfiguration(HostingEnv.IsDevelopment())
                // DICOS EXTENSIONS
                .AddDicosRepositories()
                .AddDicosGraphQLSchemas();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app
                // CORE EXTENSIONS
                .UseCoreDebug(Configuration, env, loggerFactory)
                .UseCoreGraphQLPlayGround()
                .UseCoreGraphQLSchema();
        }
    }
}
