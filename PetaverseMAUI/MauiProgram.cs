using CommunityToolkit.Maui;
using Microsoft.Maui.Handlers;
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
                fonts.AddFont("FluentSystemIcons-Regular.ttf", FontNames.FluentSystemIconsRegular);

                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

                fonts.AddFont("SmoochSans-Bold.ttf", FontNames.SmoochSansBold);
                fonts.AddFont("SmoochSans-Regular.ttf", FontNames.SmoochSansRegular);

                fonts.AddFont("Inter-Black.ttf", FontNames.InterBlack);
                fonts.AddFont("Inter-Bold.ttf", FontNames.InterBold);
                fonts.AddFont("Inter-ExtraBold.ttf", FontNames.InterExtraBold);
                fonts.AddFont("Inter-ExtraLight.ttf", FontNames.InterExtraLight);
                fonts.AddFont("Inter-Light.ttf", FontNames.InterLight);
                fonts.AddFont("Inter-Medium.ttf", FontNames.InterMedium);
                fonts.AddFont("Inter-Regular.ttf", FontNames.InterRegular);
                fonts.AddFont("Inter-SemiBold.ttf", FontNames.InterSemiBold);
                fonts.AddFont("Inter-Thin.ttf", FontNames.InterThin);
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
            ImageHandler.Mapper.PrependToMapping(nameof(Microsoft.Maui.IImage.Source), (handler, view) => PrependToMappingImageSource(handler, view));
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

#if __ANDROID__
    public static void PrependToMappingImageSource(IImageHandler handler, Microsoft.Maui.IImage image)
    {
        handler.PlatformView?.Clear();
    }
#endif

    static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<IAppInfo>(AppInfo.Current);
        builder.Services.AddSingleton<IPreferences>(Preferences.Default);
        //builder.Services.AddSingleton<IMessagingCenter>(MessagingCenter.Instance);

        builder.Services.AddSingleton<IAppNavigator, AppNavigator>();
        //builder.Services.AddSingleton<IAppSettingsService, AppSettingsService>();

        builder.Services.AddTransient<IWelcomeService, WelcomeService>();
        builder.Services.AddTransient<IPetProfileService, PetProfileService>();

        return builder;
    }

    static MauiAppBuilder RegisterPages(this MauiAppBuilder builder)
    {
        builder.Services.AddPage<WelcomePage, WelcomePageViewModel>();
        builder.Services.AddPage<WalkthroughPage, WalkthroughPageViewModel>();
        builder.Services.AddPage<SignInPage, SignInPageViewModel>();
        builder.Services.AddPage<SignUpPage, SignUpPageViewModel>();
        builder.Services.AddPage<ForgotPasswordPage, ForgotPasswordPageViewModel>();
        builder.Services.AddPage<ProfilePage, ProfilePageViewModel>();
        builder.Services.AddPage<PetsProfilePage, PetProfilePageViewModel>();
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
