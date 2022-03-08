using Autofac;
using Autofac.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


ConfigureContainer(builder);


// Add services to the container.
ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
Configure(app);





// --- method --- //



void ConfigureServices(IServiceCollection services)
{

    services.AddControllersWithViews();


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

    app.UseAuthorization();


    app.UseEndpoints(endpoints =>
    {

        endpoints.MapControllerRoute(
                name : "areas",
                pattern : "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );


        endpoints.MapControllerRoute(
                name : "default",
                pattern : "{controller=Home}/{action=Index}/{id?}"
            );

    });


    app.Run();
}



void ConfigureContainer(WebApplicationBuilder builder)
{

    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

    builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
    {
       
    });

}