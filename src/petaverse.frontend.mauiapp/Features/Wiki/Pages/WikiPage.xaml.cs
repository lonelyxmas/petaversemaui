using CommunityToolkit.Maui.Views;

namespace petaverse.frontend.mauiapp;

public partial class WikiPage
{
    private WikiPageViewModel viewModel;
    public WikiPage(WikiPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = viewModel = vm;
    }

    #region [Event Handler]
    private void BasePage_SizeChanged(object sender, EventArgs e)
    {
        if (Window.Width < 500)
        {
            if (viewModel is not null)
            {
                viewModel.Span = 1;
                viewModel.IsSpeciesFrameInfoVisible = false;
                return;
            }
        }
        else if (Window.Width < 900)
        {
            if (viewModel is not null)
            {
                viewModel.Span = 2;
                viewModel.IsSpeciesFrameInfoVisible = true;
                return;
            }
        }
        else if (Window.Width < 2000)
        {
            if (viewModel is not null)
            {
                viewModel.Span = 3;
                viewModel.IsSpeciesFrameInfoVisible = true;
                return;
            }
        }
    }

    private void BreedHandler_SelectBreedList(BreedCardModel breed)
    {
        //PetsCollectionView.ScrollTo(pet, animate: true);
        viewModel.NavigateToBreedDetailCommand.Execute(breed);
    }
    #endregion

    private async void ScanBreed_Clicked(object sender, EventArgs e)
    {
        var predictTuple = await viewModel.OpenCameraAsync();
        if (predictTuple != null)
            await this.ShowPopupAsync(new AIBreedDetectorToolkitPopup(predictTuple.Item1, predictTuple.Item2));
    }
}