using CommunityToolkit.Mvvm.Messaging.Messages;

namespace PetaverseMAUI;

public class PetListCreateMessage : ValueChangedMessage<CreatePetFormModel>
{
    public PetListCreateMessage(CreatePetFormModel value) : base(value)
    { }
}
