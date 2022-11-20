using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Platform;

namespace PetaverseMAUI;

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
			.ConfigureEssentials(essentials =>
			{
				essentials.UseVersionTracking();
			})
            .RegisterServices()
            .RegisterPages();

        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoBorderEntry", (handler, view) =>
        {
#if ANDROID
            handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
#elif IOS
            handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif WINDOWS
            handler.PlatformView.FontWeight = Microsoft.UI.Text.FontWeights.Thin;
#endif
        });

        Microsoft.Maui.Handlers.PageHandler.Mapper.AppendToMapping("Popup", (handler, view) =>
        {
#if ANDROID
            //handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
#elif IOS
            //if (view is BasePopup popup)
            //{
            //    handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
            //}
#elif WINDOWS
            //handler.PlatformView.FontWeight = Microsoft.UI.Text.FontWeights.Thin;
#endif
        });

        return builder.Build();
	}

    static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<IAppInfo>(AppInfo.Current);
        builder.Services.AddSingleton<IPreferences>(Preferences.Default);
        builder.Services.AddSingleton<IMessagingCenter>(MessagingCenter.Instance);

        builder.Services.AddSingleton<IAppNavigator, AppNavigator>();
        //builder.Services.AddSingleton<IAppSettingsService, AppSettingsService>();

        builder.Services.AddTransient<IWelcomeService, WelcomeService>();

        return builder;
    }

    static MauiAppBuilder RegisterPages(this MauiAppBuilder builder)
    {
        builder.Services.AddPage<WelcomePage, WelcomePageViewModel>();
        builder.Services.AddPage<WalkthroughPage, WalkthroughPageViewModel>();
        return builder;
    }

    static IServiceCollection AddPage<TPage, TViewModel>(this IServiceCollection services)
    where TPage : BasePage where TViewModel : BaseViewModel
    {
        services.AddTransient<TPage>();
        services.AddTransient<TViewModel>();
        return services;
    }
}
