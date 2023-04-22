using CommunityToolkit.Maui;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using System.Reflection;

namespace PetaverseMAUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        var isLocal = false;

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
            })
            .ConfigureEssentials(essentials =>
            {
                essentials.UseVersionTracking();
            });
        //.RegisterPages()
        //.RegisterPopups()
        //.RegisterServices()
        //.RegisterRefitApi(isLocal);

        //#if ANDROID
        //        ImageHandler.Mapper.AppendToMapping(nameof(ImageView.Drawable), async (handler, view) =>
        //        {
        //            if (view.Source is UriImageSource uriImageSource)
        //                try
        //                {
        //                    byte[] imageData;
        //                    using (var response = await _httpClient.GetAsync(uriImageSource.Uri))
        //                    {
        //                        imageData = await response.Content.ReadAsByteArrayAsync();
        //                    }
        //                    handler.PlatformView.SetImageDrawable(new BitmapDrawable(BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length)));
        //                }
        //                catch
        //                {
        //                };
        //        });
        //#endif

        EntryHandler.Mapper.AppendToMapping("NoBorderEntry", (handler, view) =>
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

        PageHandler.Mapper.AppendToMapping("Popup", (handler, view) =>
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



    static MauiAppBuilder RegisterPopups(this MauiAppBuilder builder)
    {
        //builder.Services.AddPopup<AddPetPopup, AddPetPopupViewModel>(AppRoutes.AddPetPopup);

        return builder;
    }

    static MauiAppBuilder RegisterRefitApi(this MauiAppBuilder builder, bool isLocal)
    {
        //builder.Services.AddRefitClient<IPetaverseAPIAuthenticationRefit>()
        //                .ConfigureHttpClient(c => c.BaseAddress = new Uri(!isLocal
        //                                                                  ? "https://petaverserestapi.azurewebsites.net/api"
        //                                                                  : "https://localhost:54781/api"));

        //builder.Services.AddRefitClient<IPetaverseAPIUserProfileRefit>()
        //        .ConfigureHttpClient(c => c.BaseAddress = new Uri(!isLocal
        //                                                          ? "https://petaverserestapi.azurewebsites.net/api"
        //                                                          : "https://localhost:54781/api"));
        return builder;
    }

    static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<IAppInfo>(AppInfo.Current);
        builder.Services.AddSingleton<IPreferences>(Preferences.Default);
        //builder.Services.AddSingleton<IMessagingCenter>(MessagingCenter.Instance);

        builder.Services.AddSingleton<IAppNavigator, AppNavigator>();
        //builder.Services.AddSingleton<ISecureStorageService, SecureStorageService>();
        ////builder.Services.AddSingleton<IAppSettingsService, AppSettingsService>();

        //builder.Services.AddTransient<IFilePicker, FilePicker>();
        //builder.Services.AddTransient<IWikiService, FakeWikiService>();
        //builder.Services.AddTransient<IWelcomeService, WelcomeService>();
        //builder.Services.AddTransient<IPetsListService, FakePetListService>();
        //builder.Services.AddTransient<IPetProfileService, PetProfileService>();
        //builder.Services.AddTransient<IProfileService, PetaverseAPIUserProfileRefit>();
        //builder.Services.AddTransient<IAuthenticationService, PetaverseAPIAuthenticationRefit>();
        return builder;
    }

    static MauiAppBuilder RegisterPages(this MauiAppBuilder builder, string pattern = "Page")
    {
        var assemblies = new Assembly[] { typeof(MauiProgram).Assembly };
        var pageTypes = assemblies.SelectMany(a => a.GetTypes().Where(a => a.Name.EndsWith(pattern) && !a.IsAbstract && !a.IsInterface));
        foreach (var pageType in pageTypes)
        {
            var viewModelFullName = $"{pageType.FullName}ViewModel";
            var viewModelType = Type.GetType(viewModelFullName);

            builder.Services.AddTransient(pageType);

            if (viewModelType != null)
                builder.Services.AddTransient(viewModelType);

            Routing.RegisterRoute(pageType.FullName, pageType);
        }

        return builder;
    }


    static IServiceCollection AddPopup<TPopup, TViewModel>(this IServiceCollection services, string name)
    where TPopup : BasePopup where TViewModel : BaseViewModel
    {
        Routing.RegisterRoute(name, typeof(TPopup));
        services.AddTransient<TPopup>();
        services.AddTransient<TViewModel>();
        return services;
    }
}
