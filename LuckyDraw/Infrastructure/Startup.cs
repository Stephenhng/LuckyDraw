using LuckyDraw.Components;
using LuckyDraw.Components.Account;
using LuckyDraw.Data;
using LuckyDraw.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Radzen;

namespace LuckyDraw.Infrastructure;

public class Startup (IConfiguration configuration)
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorComponents()
           .AddInteractiveServerComponents();
        services.AddRadzenComponents();

        services.AddAutoMapper(typeof(Startup));

        services.AddCascadingAuthenticationState();
        services.AddScoped<IdentityUserAccessor>();
        services.AddScoped<IdentityRedirectManager>();
        services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

        var connectionString = configuration.GetConnectionString("LuckyDraw") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        services.AddDbContextPool<ApplicationDbContext>(options => options
            .UseSqlServer(connectionString)
            .UseLazyLoadingProxies());
        services.AddDatabaseDeveloperPageExceptionFilter();

        services
               .AddIdentity<ApplicationUser, IdentityRole>()
               .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultTokenProviders();

        services.AddAuthentication(options =>
        {
            options.DefaultScheme = IdentityConstants.ApplicationScheme;
            options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
        });

        services.AddHttpContextAccessor();

        services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

        services.AddScoped<IParticipantService, ParticipantService>();
        services.AddScoped<IPrizeService, PrizeService>();
        services.AddScoped<IWinnerService, WinnerService>();

    }

    public void Configure(IApplicationBuilder application, IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            application.UseMigrationsEndPoint();
        }
        else
        {
            application.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            application.UseHsts();
        }

        application.UseHttpsRedirection();

        application.UseStaticFiles();
        application.UseRouting();
        application.UseAuthentication();
        application.UseAuthorization();
        application.UseAntiforgery();

        application.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();
            endpoints.MapAdditionalIdentityEndpoints();
        });
    }
}
