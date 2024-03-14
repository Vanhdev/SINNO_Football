using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using Radzen;
using SINNO_FC.Services;

namespace SINNO_FC
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddScoped<ContextMenuService>();
            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<NotificationService>();
            builder.Services.AddScoped<TooltipService>();

            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IMemberServcie, MemberService>();
            builder.Services.AddScoped<IVoteServcie, VoteService>();
            builder.Services.AddRadzenComponents();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif


            DB.Start(FileSystem.Current.AppDataDirectory + "/app_database");

            return builder.Build();
        }
    }
}
