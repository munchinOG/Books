using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Munchin.BookStore.Data;
using Munchin.BookStore.Models;
using Munchin.BookStore.Repository;

namespace Munchin.BookStore
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup( IConfiguration configuration )
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices( IServiceCollection services )
        {
            services.AddDbContext<BookStoreContext>(
                options => options.UseSqlServer( _configuration.GetConnectionString( "DefaultConnection" ) ) );

            services.AddControllersWithViews();
#if DEBUG
            services.AddRazorPages().AddRazorRuntimeCompilation();

            // Uncomment this code to disable client side validations.
            //    .AddViewOptions(option => 
            //{
            //    option.HtmlHelperOptions.ClientValidationEnabled = false;
            //} );
#endif
            services.AddScoped<IBookRepositry, BookRepositry>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddSingleton<IMessageRepository, MessageRepository>();

            services.Configure<NewBookAlertConfig>( "InternalBook", _configuration.GetSection( "NewBookAlert" ) );
            services.Configure<NewBookAlertConfig>( "ThirdPartyBook", _configuration.GetSection( "ThirdPartyBook" ) );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure( IApplicationBuilder app, IWebHostEnvironment env )
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints( endpoints =>
             {
                 endpoints.MapDefaultControllerRoute();

                 //endpoints.MapControllerRoute(
                 //    name: "Default",
                 //    pattern: "bookApp/{controller=Home}/{action=Index}/{id?}" );

                 //endpoints.Map( "/", async context =>
                 //{
                 //    await context.Response.WriteAsync( "Hello World" );
                 //} );
             } );
        }
    }
}
