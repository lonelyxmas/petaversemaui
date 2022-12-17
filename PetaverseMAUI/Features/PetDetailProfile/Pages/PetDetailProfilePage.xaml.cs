namespace PetaverseMAUI;

public partial class PetDetailProfilePage
{
	public PetDetailProfilePage(PetDetailProfilePageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}