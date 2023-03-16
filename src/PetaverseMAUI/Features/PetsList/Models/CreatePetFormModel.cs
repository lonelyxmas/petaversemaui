namespace PetaverseMAUI;

public partial class CreatePetFormModel : BaseFormModel
{
    [ObservableProperty]
    [Required(ErrorMessage = "Please enter pet name")]
    string petName;

    [ObservableProperty]
    int speciesId;

    [ObservableProperty]
    int breedId;

    [ObservableProperty]
    DateTime? dateOfBirth;

    [ObservableProperty]
    List<string> selectedColors;

    public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> PetNameErrors => GetErrors(nameof(PetName));

    protected override string[] ValidatableAndSupportPropertyNames => new[]
{
        nameof(PetName)
    };
}
