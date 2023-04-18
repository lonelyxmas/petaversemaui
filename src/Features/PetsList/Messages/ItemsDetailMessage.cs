using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace PetaverseMAUI;

public class ItemsDetailMessage : ValueChangedMessage<string>
{

    public ItemsDetailMessage(string value) : base(value)
    {
    }
}
