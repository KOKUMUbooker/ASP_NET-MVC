using k.CustomRouteConstraints.Models;

namespace RoutingInASPDotNetCoreMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Configuring the Custom Route Constraint Service using AddRouting Method
            builder.Services.AddRouting(options =>
            {
                options.ConstraintMap.Add("alphanumeric", typeof(AlphaNumericConstraint));
            });

            //Configuring the Custom Route Constraint Service using Configure Method
            //builder.Services.Configure<RouteOptions>(routeOptions =>
            //{
            //    routeOptions.ConstraintMap.Add("alphanumeric", typeof(AlphaNumericConstraint));
            //});

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "CustomRoute",
                pattern: "{controller}/{action}/{id:alphanumeric?}",
                defaults: new { controller = "Home", action = "Index"}
            );

            app.Run();
        }
    }
}