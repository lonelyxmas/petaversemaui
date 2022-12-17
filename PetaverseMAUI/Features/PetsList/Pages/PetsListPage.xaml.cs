namespace PetaverseMAUI;

public partial class PetsListPage
{
	public PetsListPage(PetsListPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}

    private void PetHandler_SelectPet(PetProfileCardModel pet)
    {
		PetsCollectionView.ScrollTo(pet, animate: true);
    }
}