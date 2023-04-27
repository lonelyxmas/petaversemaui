using CommunityToolkit.Mvvm.Messaging.Messages;

namespace petaverse.frontend.mauiapp;

public class CreatePetMessage : ValueChangedMessage<CreatePetMessageModel>
{
    public CreatePetMessage(CreatePetMessageModel value) : base(value)
    { }
}