using Autofac;
using Autofac.Extensions.DependencyInjection;
using CMSApplication.Domain.Entities.MainEntities.UserEntities;
using CMSApplication.Injections;
using CMSApplication.Persistance.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.
ConfigureContainer(builder);
ConfigureServices(builder.Services, builder.Configuration);






var app = builder.Build();

// Configure the HTTP request pipeline.

Configure(app);



// --- method --- //



void ConfigureServices(IServiceCollection services, IConfiguration config)
{

    services.AddControllersWithViews();

    services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseSqlServer(connectionString: config["ConnectionStrings:Default"]);
    });

    services.AddIdentity<User, Role>().AddEntityFrameworkStores<ApplicationDbContext>();


    services.ConfigureApplicationCookie(options =>
    {
        options.LoginPath = "/Identity/SignIn";
        options.LogoutPath = "/Home/Index";
        options.ExpireTimeSpan = TimeSpan.FromDays(7);
        options.AccessDeniedPath = "/Users/AccessDenied";
    });


}




void ConfigureContainer(WebApplicationBuilder builder)
{

    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

    builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
    {

        builder.RegisterContainerDependency();


    });

}





void Configure(WebApplication builder)
{



    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();


    app.UseEndpoints(endpoints =>
    {

        endpoints.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );


        endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );

    });


    app.Run();



}


