using CommunityToolkit.Mvvm.DependencyInjection;

namespace PetaverseMAUI;

public class PetsSearchHandler : SearchHandler
{
    #region [CTor]
    public PetsSearchHandler()
    {
        this.Pets = new();
    }
    #endregion

    #region [Properties]
    public static readonly BindableProperty PetsProperty = BindableProperty.Create(nameof(Pets),
                                                                                   typeof(ObservableCollection<PetProfileCardsGroupModel>),
                                                                                   typeof(PetsSearchHandler),
                                                                                   new ObservableCollection<PetProfileCardsGroupModel>(),
                                                                                   BindingMode.OneWay);
    public ObservableCollection<PetProfileCardsGroupModel> Pets
    {
        get => (ObservableCollection<PetProfileCardsGroupModel>)GetValue(PetsProperty);
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
            ItemsSource = Pets.SelectMany(x => x).Where(pet => pet.Name.ToLower().Contains(newValue.ToLower())).ToList();
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
