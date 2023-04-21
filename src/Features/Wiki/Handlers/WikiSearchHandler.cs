using CommunityToolkit.Mvvm.DependencyInjection;

namespace PetaverseMAUI;

public class WikiSearchHandler : SearchHandler
{
    #region [ CTor ]
    public WikiSearchHandler()
    {
        this.BreedList = new();
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty BreedListProperty = BindableProperty.Create(nameof(BreedList),
                                                                                   typeof(ObservableCollection<SpeciesPivotModel>),
                                                                                   typeof(WikiSearchHandler),
                                                                                   new ObservableCollection<SpeciesPivotModel>(),
                                                                                   BindingMode.OneWay);
    #endregion

    #region [ Properties ]
    public ObservableCollection<SpeciesPivotModel> BreedList
    {
        get => (ObservableCollection<SpeciesPivotModel>)GetValue(BreedListProperty);
        set => SetValue(BreedListProperty, value);
    }
    #endregion

    #region [Delegates]
    public delegate void SelecBreedListEventHandler(BreedCardModel breed);
    #endregion

    #region [ Event Handlers ]
    public event SelecBreedListEventHandler SelectBreedList;

    protected override void OnQueryChanged(string oldValue, string newValue)
    {
        base.OnQueryChanged(oldValue, newValue);

        if (string.IsNullOrWhiteSpace(newValue))
        {
            ItemsSource = null;
        }
        else
        {
            var list = new List<BreedCardModel>();
            foreach (var specie in BreedList)
            {
                foreach (var breed in specie.BreedCards.Where(species => species.BreedName.ToLower().Contains(newValue.ToLower())).ToList())
                {
                    list.Add(breed);
                }
            }
            ItemsSource = list;
        }
    }

    protected override void OnItemSelected(object item)
    {
        base.OnItemSelected(item);
        var selectedBreed = item as BreedCardModel;
        SelectBreedList.Invoke(selectedBreed);
    }

    #endregion
}
