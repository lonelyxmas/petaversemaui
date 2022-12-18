namespace PetaverseMAUI;

public partial class PetsListPage
{
	private PetsListPageViewModel _viewModel;
    public PetsListPage(PetsListPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = _viewModel = vm;
	}

    private void PetHandler_SelectPet(PetProfileCardModel pet)
    {
		PetsCollectionView.ScrollTo(pet, animate: true);
		_viewModel.NavigateToProfileDetailCommand.Execute(pet);
    }
}