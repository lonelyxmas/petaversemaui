namespace PetaverseMAUI;

public partial class PetsProfilePage
{
	public PetsProfilePage(PetProfilePageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}