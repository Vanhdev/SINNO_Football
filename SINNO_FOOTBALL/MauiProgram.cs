using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using SINNO_FOOTBALL.Views;
using SINNO_FOOTBALL.ViewModels;
using SINNO_FOOTBALL.Services;

namespace SINNO_FOOTBALL
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .RegisterServices()
                .RegisterViewModels()
                .RegisterViews();

            Routing.RegisterRoute("Home", typeof(HomePage));
            Routing.RegisterRoute("Calendar", typeof (CalendarPage));
            Routing.RegisterRoute("Detail", typeof (DetailPage));
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<INavigationService, NavigationService>();
            builder.Services.AddSingleton<IAuthService, AuthService>();
            return builder;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<LoginPageViewModel>();
            builder.Services.AddSingleton<CardPageViewModel>();
            return builder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddSingleton<CardPage>();
            return builder;
        }
    }
}
