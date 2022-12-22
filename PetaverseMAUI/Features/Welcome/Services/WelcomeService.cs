namespace PetaverseMAUI;

public class WelcomeService : IWelcomeService
{
    public Task<IEnumerable<WalkthroughItemModel>> GetWalkthroughItemsAsync()
    {
        return Task.FromResult(GenerateItems());
    }

    static IEnumerable<WalkthroughItemModel> GenerateItems()
    {
        return new[]
        {
                new WalkthroughItemModel
                {
                    Title = "Chào mừng bạn đến với Petaverse",
                    Subtitle = "Petaverse là mạng xã hội giành cho những người yêu thương thú cưng, và dù bạn không có thú cưng bạn vẫn có thể giúp những người khác trong cộng đồng",
                    Image = "walkthrough1.svg",
                },
                new WalkthroughItemModel
                {
                    Title = "Thế giới rộng lớn về chó và mèo",
                    Subtitle = "Petaverse có thông tin hơn 100 loài chó và 100 lòai mèo đang đợi bạn khám phá, kèm với những kiến thức chuyên sâu đến từ thú y và những người giàu kinh nghiệm",
                    Image = "walkthrough2.svg"
                },
                new WalkthroughItemModel
                    {
                        Title = "Cộng đồng an ninh",
                        Subtitle = "Petaverse là cộng đồng bảo mật và đáng tin cậy cho các fosterers và người sỡ hữu thú cưng có thể giảm rất nhiều mối lo ngại khi chuyển giao quyền nuôi hoặc hỗ trợ cho những sự kiện kêu gọi",
                        Image = "walkthrough3.svg",
                    }
            };
    }
}
