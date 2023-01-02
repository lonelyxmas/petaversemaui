namespace PetaverseMAUI;

public partial class PetsListPage
{
	private PetsListPageViewModel viewModel;
    public PetsListPage(PetsListPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = viewModel = vm;

        PetsCollectionView.ItemsLayout = new GridItemsLayout(2, ItemsLayoutOrientation.Vertical);
    }

    private void BasePage_SizeChanged(object sender, EventArgs e)
    {
        if (Window.Width < 500)
        {
            if (viewModel is not null)
            {
                viewModel.CurrentDeviceState = "Phone";

                PetsCollectionView.ItemsLayout = new GridItemsLayout(2, ItemsLayoutOrientation.Vertical);
            }
        }
        else if (Window.Width < 900)
        {
            if (viewModel is not null)
            {
                viewModel.CurrentDeviceState = "Tablet";
                //viewModel.Span = 3;
                PetsCollectionView.ItemsLayout = new GridItemsLayout(3, ItemsLayoutOrientation.Vertical);
            }
        }
        else if (Window.Width < 2000)
        {
            if (viewModel is not null)
            {
                viewModel.CurrentDeviceState = "Desktop";
                //viewModel.Span = 4;
                PetsCollectionView.ItemsLayout = new GridItemsLayout(4, ItemsLayoutOrientation.Vertical);
            }
        }
    }

    private void PetHandler_SelectPet(PetProfileCardModel pet)
    {
		//PetsCollectionView.ScrollTo(pet, animate: true);
		viewModel.NavigateToProfileDetailCommand.Execute(pet);
    }
}