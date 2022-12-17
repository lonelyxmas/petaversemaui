namespace PetaverseMAUI;

public class PetProfileService : IPetProfileService
{

    public Task<List<PetaverseMediaThumbnail>> FakeThumbnails()
    {
        return Task.Run(() =>
        {
            var faker = new Faker<PetaverseMediaThumbnail>();
            faker.RuleFor(x => x.ThumbnailUrl, setter => setter.Image.LoremFlickrUrl(120, 120, "cat"));
            return faker.Generate(200);
        });
    }
}
