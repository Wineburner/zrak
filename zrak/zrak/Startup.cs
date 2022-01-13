using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using zrak.Builders;
using zrak.Services;
using zrak.Stores;
using zrak.Mappers;
using zrak.Factory;

namespace zrak
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
            var mongoStore = new MongoStore(Configuration);
            services.AddSingleton<IBlogStore>(mongoStore);
            services.AddSingleton<ITicTacToeStore>(mongoStore);
            services.AddSingleton<IBlogService, BlogService>();
            services.AddSingleton<IHelloService, HelloService>();
            services.AddSingleton<ITicTacToeService, TicTacToeService>();
            services.AddSingleton<IBlogBuilder, BlogBuilder>();
            services.AddSingleton<ITicTacToeBuilder, TicTacToeBuilder>();
            services.AddSingleton<ITicTacToeIndexMapper, TicTacToeIndexMapper>();
            services.AddSingleton<ITicTacToeSpaceMapper, TicTacToeSpaceMapper>();
            services.AddSingleton<ITicTacToeModelFactory, TicTacToeModelFactory>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
