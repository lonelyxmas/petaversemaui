namespace PetaverseMAUI;

public partial class WikiPage
{
	public WikiPage(WikiPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}