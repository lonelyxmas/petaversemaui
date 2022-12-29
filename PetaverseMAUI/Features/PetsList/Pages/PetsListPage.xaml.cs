namespace PetaverseMAUI;

public partial class PetsListPage
{
	private PetsListPageViewModel viewModel;
    public PetsListPage(PetsListPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = viewModel = vm;
	}

    private void BasePage_SizeChanged(object sender, EventArgs e)
    {
        if (Window.Width < 500)
        {
            if (viewModel is not null)
            {
                viewModel.CurrentDeviceState = "Phone";

                //PetsCollectionView.ItemsLayout = this.Resources["PetsCollectionViewTabletLayout"] as ItemsLayout;
            }
        }
        else if (Window.Width < 900)
        {
            if (viewModel is not null)
            {
                viewModel.CurrentDeviceState = "Tablet";

                //PetsCollectionView.ItemsLayout = this.Resources["PetsCollectionViewTabletLayout"] as ItemsLayout;
            }
        }
        else if (Window.Width < 2000)
        {
            if (viewModel is not null)
            {
                viewModel.CurrentDeviceState = "Desktop";

                //PetsCollectionView.ItemsLayout = this.Resources["PetsCollectionViewDesktopLayout"] as ItemsLayout;
            }
        }
    }

    private void PetHandler_SelectPet(PetProfileCardModel pet)
    {
		PetsCollectionView.ScrollTo(pet, animate: true);
		viewModel.NavigateToProfileDetailCommand.Execute(pet);
    }
}