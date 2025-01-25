using HotelReservation.WebHelper;
using HotelReservation.WebUI.Middleware;

namespace HotelReservation.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews()
                 .AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null);
            builder.Services.AddSession();
            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();
            app.UseSession();
            var httpContext  = app.Services.GetRequiredService<IHttpContextAccessor>();
            AppHttpContext.Configure(httpContext);

            app.UseGlobalExceptionHandlerMiddleware();
            app.UseSessionNullCheckMiddleware();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
