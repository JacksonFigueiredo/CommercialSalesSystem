using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesWebCommercial.Data;
using SalesWebCommercial.Services;

namespace SalesWebCommercial
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<SalesWebCommercialContext>(options =>
            options.UseMySQL(builder.Configuration.GetConnectionString("SalesWebCommercialContext") ?? throw new InvalidOperationException("Connection string 'SalesWebCommercialContext' not found."),
                builder => builder.MigrationsAssembly("SalesWebCommercial")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<SeedingService>();
            builder.Services.AddScoped<SellerService>();
            builder.Services.AddScoped<DepartmentService>();
            builder.Services.AddScoped<SalesRecordService>();


            var app = builder.Build();


            using (var scope = app.Services.CreateScope())
            {
                var seedingService = scope.ServiceProvider.GetService<SeedingService>();
                seedingService.Populate();
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            else
            {


            }

            app.UseHttpsRedirection();
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