namespace PetaverseMAUI;

public class PetsSearchHandler : SearchHandler
{
    #region [CTor]
    public PetsSearchHandler()
    {
        Pets = new();
    }
    #endregion

    #region [Properties]
    public static readonly BindableProperty PetsProperty = BindableProperty.Create(nameof(Pets),
                                                                        typeof(ObservableCollection<PetProfileCardModel>),
                                                                        typeof(PetsSearchHandler),
                                                                        new ObservableCollection<PetProfileCardModel>(),
                                                                        BindingMode.OneWay);
    public ObservableCollection<PetProfileCardModel> Pets
    {
        get => (ObservableCollection<PetProfileCardModel>)GetValue(PetsProperty);
        set => SetValue(PetsProperty, value);
    }
    #endregion

    #region [Delegates]
    public delegate void SelecPetEventHandler(PetProfileCardModel pet);
    #endregion

    #region [Event Handlers]
    public event SelecPetEventHandler SelectPet;

    protected override void OnQueryChanged(string oldValue, string newValue)
    {
        base.OnQueryChanged(oldValue, newValue);

        if (string.IsNullOrWhiteSpace(newValue))
        {
            ItemsSource = null;
        }
        else
        {
            ItemsSource = Pets.Where(pet => pet.Name.ToLower().Contains(newValue.ToLower())).ToList();
        }
    }

    protected override async void OnItemSelected(object item)
    {
        base.OnItemSelected(item);
        var selectedPet = item as PetProfileCardModel;
        SelectPet.Invoke(selectedPet);
    }

    #endregion
}
