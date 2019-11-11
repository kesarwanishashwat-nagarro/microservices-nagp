using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Steeltoe.CircuitBreaker.Hystrix;
using WebApp.Models;

namespace WebApp
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.Configure<Configuration>(Configuration);
            RegisterExternalServices(services);
            RegisterHystrixCommands(services);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }

        private void RegisterExternalServices(IServiceCollection services)
        {
            services.AddTransient<IGatewayService<Account>, GatewayService<Account>>();
            services.AddTransient<IGatewayService<Customer>, GatewayService<Customer>>();
            services.AddTransient<IGatewayService<Transaction>, GatewayService<Transaction>>();
            services.AddTransient<IGatewayService<Order>, GatewayService<Order>>();
            services.AddTransient<IGatewayService<string>, GatewayService<string>>();
        }
        private void RegisterHystrixCommands(IServiceCollection services)
        {
            services.AddHystrixCommand<PostCommand<Account>>("GatewayCommands", Configuration);
            services.AddHystrixCommand<PostCommand<Customer>>("GatewayCommands", Configuration);
            services.AddHystrixCommand<PostCommand<Transaction>>("GatewayCommands", Configuration);
            services.AddHystrixCommand<PostCommand<Order>>("GatewayCommands", Configuration);
            services.AddHystrixCommand<PutCommand<Customer>>("GatewayCommands", Configuration);
            services.AddHystrixCommand<PutCommand<Account>>("GatewayCommands", Configuration);
            services.AddHystrixCommand<GetAllCommand<Account>>("GatewayCommands", Configuration);
            services.AddHystrixCommand<GetAllCommand<Customer>>("GatewayCommands", Configuration);
            services.AddHystrixCommand<GetAllCommand<Transaction>>("GatewayCommands", Configuration);
            services.AddHystrixCommand<GetAllCommand<Order>>("GatewayCommands", Configuration);
            services.AddHystrixCommand<GetCommand<Account, string>>("GatewayCommands", Configuration);
            services.AddHystrixCommand<GetCommand<Customer, string>>("GatewayCommands", Configuration);
            services.AddHystrixCommand<GetCommand<Transaction, string>>("GatewayCommands", Configuration);
            services.AddHystrixCommand<GetStringCommand<Account>>("GatewayCommands", Configuration);
            services.AddHystrixCommand<GetStringCommand<Transaction>>("GatewayCommands", Configuration);
            services.AddHystrixCommand<DeleteCommand>("GatewayCommands", Configuration);
        }

    }
}
