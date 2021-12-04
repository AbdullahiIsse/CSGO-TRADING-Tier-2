using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SEP3_tier2.Data;
using SEP3_tier2.GraphQL;


namespace SEP3_tier2
{
    public class Startup
    {
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddInMemorySubscriptions();
            services.AddScoped<IUserData, UserData>();
            services.AddScoped<IItemData, ItemData>();
            services.AddScoped<IOfferData, OfferData>();
            services.AddScoped<IWalletData, WalletData>();
            services.AddScoped<IPaymentData, PaymentData>();
            services.AddScoped<IChatData, ChatData>();
            services.AddScoped<IWalletData, WalletData>();
            services.AddScoped<IShoppingCartData, ShoppingCartData>();

            services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddFiltering()
                .AddSorting()
                .AddMutationType<Mutation>()
                .AddSubscriptionType<Subscription>();  
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseWebSockets();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                app.UseRouting().UseEndpoints(endpoints => { endpoints.MapGraphQL(); });
            });
            
           
        }
    }
}