using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace PetaverseMAUI;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();

        //MauiExceptions.UnhandledException += (sender, args) => HandleException(args);
        AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;
    }

    //Connect to a logging system
    Task HandleException(UnhandledExceptionEventArgs args)
    {
        var options = new SnackbarOptions
        {
            BackgroundColor = AppColors.Purple,
            TextColor = AppColors.White,
            ActionButtonTextColor = AppColors.Pink,
            CornerRadius = new CornerRadius(Dimensions.ButtonCornerRadius),
            Font = Microsoft.Maui.Font.OfSize(FontNames.InterRegular, Dimensions.FontSizeT6),
            ActionButtonFont = Microsoft.Maui.Font.OfSize(FontNames.SmoochSansBold, Dimensions.FontSizeT6),
            CharacterSpacing = 0.5
        };
        var snackbar = Snackbar.Make("Exception", null, "OK", TimeSpan.FromSeconds(5), options);
        return snackbar.Show();
    }

    private void CurrentDomain_FirstChanceException(object sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine($"********************************** UNHANDLED EXCEPTION! Details: {e.Exception.ToString()}");
    }
}
