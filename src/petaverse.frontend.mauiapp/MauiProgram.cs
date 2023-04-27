using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Refit;
using System.Reflection;

namespace petaverse.frontend.mauiapp;

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
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("FluentSystemIcons-Regular.ttf", FontNames.FluentSystemIconsRegular);
            })
            .ConfigureEssentials(essentials =>
            {
                essentials.UseVersionTracking();
            })
            .RegisterPages()
            .RegisterPopups()
            .RegisterServices()
            .RegisterRefitApi(isLocal);

        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
        builder.Services.RegisterPetaverseFrontEndCoreServices();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }



    static MauiAppBuilder RegisterPopups(this MauiAppBuilder builder)
    {
        builder.Services.AddPopup<CreatePetPopup, CreatePetPopupViewModel>(AppRoutes.AddPetPopup);

        return builder;
    }

    static MauiAppBuilder RegisterRefitApi(this MauiAppBuilder builder, bool isLocal)
    {
        builder.Services.AddRefitClient<IPetaverseAPIAuthenticationRefit>()
                        .ConfigureHttpClient(c => c.BaseAddress = new Uri(!isLocal
                                                                          ? "https://petaverserestapi.azurewebsites.net/api"
                                                                          : "https://localhost:54781/api"));

        builder.Services.AddRefitClient<IPetaverseAPIUserProfileRefit>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(!isLocal
                                                                  ? "https://petaverserestapi.azurewebsites.net/api"
                                                                  : "https://localhost:54781/api"));
        return builder;
    }

    static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<IAppInfo>(AppInfo.Current);
        builder.Services.AddSingleton<IPreferences>(Preferences.Default);
        //builder.Services.AddSingleton<IMessagingCentaer>(MessagingCenter.Instance);

        builder.Services.AddTransient<ICreatePetPopupService, CreatePetPopupService>();

        builder.Services.AddSingleton<IAppNavigator, AppNavigator>();
        builder.Services.AddSingleton<ISecureStorageService, SecureStorageService>();
        //builder.Services.AddSingleton<IAppSettingsService, AppSettingsService>();

        builder.Services.AddTransient<IFilePicker, FilePicker>();
        builder.Services.AddTransient<IWikiService, FakeWikiService>();
        builder.Services.AddTransient<IWelcomeService, WelcomeService>();
        builder.Services.AddTransient<IPetsListService, FakePetListService>();
        builder.Services.AddTransient<IPetProfileService, PetProfileService>();
        builder.Services.AddTransient<IProfileService, PetaverseAPIUserProfileRefit>();
        builder.Services.AddTransient<IAuthenticationService, PetaverseAPIAuthenticationRefit>();
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
