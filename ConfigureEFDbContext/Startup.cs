using ConfigureEFDbContext.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ConfigureEFDbContext
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment hostEnvironment)
        {
            Configuration = configuration;
            HostEnvironment = hostEnvironment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment HostEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public virtual void ConfigureServices(IServiceCollection services)
        {
            this
                .AddLogging(services)
                .AddApplicationOptions(services)

                .AddDbContextConfigurerFactory(services)
                .AddEFProviderConnectionOptions(services)
                .AddDbContextConfigurer(services)

                .AddDbContext(services);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public virtual void Configure(IApplicationBuilder app)
        {
            if (HostEnvironment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseHttpsRedirection()
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints => endpoints.MapControllers());
        }

        //  To use fluent setting we return same objects
        protected virtual Startup AddLogging(IServiceCollection services)
        {
            services.AddLogging
                    (
                        builder =>
                        builder.AddConfiguration(Configuration.GetSection("Logging"))
                                .AddConsole()
                                .AddDebug()
                    );

            return this;
        }

        //  To use fluent setting we return same objects
        protected virtual Startup AddApplicationOptions(IServiceCollection services)
        {
            services
                .AddOptions()
                .Configure<EntityFrameworkOptions>(Configuration.GetSection(EntityFrameworkOptions.KEY_NAME))
                .Configure<ConnectionStringsOptions>(Configuration.GetSection(ConnectionStringsOptions.KEY_NAME))
                ;

            return this;
        }

        protected virtual Startup AddDbContextConfigurerFactory(IServiceCollection services)
        {
            services.AddSingleton<IDbContextConfigurerFactory, CacheableDbContextConfigurerFactory>();
            return this;
        }

        protected virtual Startup AddEFProviderConnectionOptions(IServiceCollection services)
        {
            services.AddSingleton<IEntityFrameworkProviderConnectionOptions, SqlServerProviderConnectionOptions>();
            return this;
        }

        protected Startup AddDbContextConfigurer(IServiceCollection services)
        {
            services.AddSingleton(serviceProvider => serviceProvider.GetService<IDbContextConfigurerFactory>().GetConfigurer());
            return this;
        }

        protected virtual Startup AddDbContext(IServiceCollection services)
        {
            AddDbContextPool<DbContext_1>(services);
            AddDbContextPool<DbContext_2>(services);
            AddDbContextPool<DbContext_3>(services);

            // Interface Segregation Principle (ISP)
            services.AddScoped<IDbContext_1>(provider => provider.GetService<DbContext_1>());
            services.AddScoped<IDbContext_2>(provider => provider.GetService<DbContext_2>());
            services.AddScoped<IDbContext_3>(provider => provider.GetService<DbContext_3>());

            return this;
        }

        private Startup AddDbContextPool<TContext>(IServiceCollection services) where TContext : DbContext
        {
            services.AddDbContextPool<TContext>
            (
                (serviceProvider, dbContextOptionsBuilder) => serviceProvider.GetService<IDbContextConfigurer>().Configure(serviceProvider, dbContextOptionsBuilder)
            );

            return this;
        }
    }
}
