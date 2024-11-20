using LuckyDraw.Infrastructure;

namespace LuckyDraw;
public class Program
{
    public static void Main(string[] args)
    {
        var application = Host.CreateDefaultBuilder(args);
        application.ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
        application.Build().Run();
    }
}
