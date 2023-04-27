namespace petaverse.frontend.mauiapp;

public partial class CreatePetForm : BaseFormModel
{
    #region [ Properties ]

    [ObservableProperty]
    [Required(ErrorMessage = "Please enter pet name")]
    [NotifyPropertyChangedFor(nameof(PetNameValid), nameof(PetNameInvalidMessage))]
    string petName;

    [ObservableProperty]
    string? bio;

    [ObservableProperty]
    int speciesId;

    [ObservableProperty]
    int breedId;

    [ObservableProperty]
    bool gender;

    [ObservableProperty]
    DateTime? dateOfBirth;

    [ObservableProperty]
    List<string> selectedColors;
    #endregion

    public bool PetNameValid
        => GetErrors(nameof(PetName)).Any() == false;

    public string PetNameInvalidMessage
        => GetErrors(nameof(PetName)).FirstOrDefault()?.ErrorMessage;

    partial void OnPetNameChanging(string value)
        => ValidateProperty(value, nameof(PetName));
}
