using LuckyDraw.Components;
using LuckyDraw.Components.Account;
using LuckyDraw.Data;
using LuckyDraw.Infrastructure.Sockets;
using LuckyDraw.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Radzen;

namespace LuckyDraw.Infrastructure;

public class Startup(IConfiguration configuration)
{
    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = configuration.GetConnectionString("LuckyDraw") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        services.AddDbContextPool<ApplicationDbContext>(options => options
            .UseSqlServer(connectionString)
            .UseLazyLoadingProxies());
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddRazorComponents()
           .AddInteractiveServerComponents();
        services.AddRadzenComponents();

        services.AddAutoMapper(typeof(Startup));
        services.AddSignalR();
        services.AddResponseCompression(opts =>
        {
            opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                ["application/octet-stream"]);
        });

        services.AddCascadingAuthenticationState();
        services.AddScoped<IdentityUserAccessor>();
        services.AddScoped<IdentityRedirectManager>();
        services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

        services
            .AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
            options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
        });

        services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

        services.AddScoped<IParticipantService, ParticipantService>();
        services.AddScoped<IPrizeService, PrizeService>();
        services.AddScoped<IWinnerService, WinnerService>();

        services.AddSingleton<HubBase>();
    }

    public void Configure(IApplicationBuilder application, IWebHostEnvironment environment)
    {
        application.UseResponseCompression();

        if (environment.IsDevelopment())
            application.UseMigrationsEndPoint();
        else
        {
            application.UseExceptionHandler("/Error");
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
            endpoints.MapHub<Lobby>("/lobby");
            endpoints.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();
            endpoints.MapAdditionalIdentityEndpoints();
        });
    }
}
