using Bogus;

namespace petaverse.frontend.mauiapp;

public class FakeWikiService : IWikiService
{
    public Task<IEnumerable<SpeciesPivotModel>> GetAllSpecies()
    {

        return Task.Run(() =>
        {
            var faker = new Faker();
            var listOfSpecies = new List<SpeciesPivotModel>();

            var listOfCats = new List<BreedCardModel>();
            var listOfDogs = new List<BreedCardModel>();

            listOfCats.Add(new BreedCardModel()
            {
                BreedName = "Tabby",
                BreedDetail = "A tabby is any domestic cat with a distinctive 'M'-shaped marking on its forehead; stripes by its eyes and across its cheeks, along its back, and around its legs and tail; and, characteristic striped, dotted, lined, flecked, banded, or swirled patterns on the body—neck, shoulders, sides, flanks, chest, and abdomen.",
                BreedImageUrl = "https://petaversestorageaccount.blob.core.windows.net/cat-breeds/Tabby.png",
                Coat = WikiPageCoatEnum.Medium,
                Energy = WikiPageEnergyEnum.Hunter,
                SheddingLevel = WikiPageSheddingLevelEnum.Heavy,
                Size = WikiPageSizeEnum.Medium
            });

            listOfCats.Add(new BreedCardModel()
            {
                BreedName = "Abyssinian",
                BreedDetail = "The Abyssinian is a breed of domestic short-haired cat with a distinctive \"ticked\" tabby coat, in which individual hairs are banded with different colors. They are also known simply as Abys.",
                BreedImageUrl = new Uri("https://petaversestorageaccount.blob.core.windows.net/cat-breeds/Abyssinian.png"),
                Coat = WikiPageCoatEnum.Medium,
                Energy = WikiPageEnergyEnum.Hunter,
                SheddingLevel = WikiPageSheddingLevelEnum.Heavy,
                Size = WikiPageSizeEnum.Medium
            });

            listOfCats.Add(new BreedCardModel()
            {
                BreedName = "Persian",
                BreedDetail = "The Persian is a heavily boned, well-balanced cat with a sweet expression and soft, round lines. This cat has large round eyes set wide apart in a large round head. The long thick coat softens the lines of the cat and accentuates the roundness in appearance.",
                BreedImageUrl = new Uri("https://petaversestorageaccount.blob.core.windows.net/cat-breeds/Persian.png"),
                Coat = WikiPageCoatEnum.Long,
                Energy = WikiPageEnergyEnum.Low,
                SheddingLevel = WikiPageSheddingLevelEnum.Heavy,
                Size = WikiPageSizeEnum.Medium,
            });

            listOfCats.Add(new BreedCardModel()
            {
                BreedName = "Turkish Angora",
                BreedDetail = "A balanced, graceful cat with a fine, silky coat that shimmers with every movement, in contrast to the firm, long muscular body beneath it.",
                BreedImageUrl = "https://petaversestorageaccount.blob.core.windows.net/cat-breeds/TurkishAngora.png",
                Coat = WikiPageCoatEnum.Long,
                Energy = WikiPageEnergyEnum.Medium,
                SheddingLevel = WikiPageSheddingLevelEnum.Heavy,
                Size = WikiPageSizeEnum.Medium
            });

            listOfCats.Add(new BreedCardModel()
            {
                BreedName = "American Short Hair",
                BreedDetail = "The American Shorthair is a true breed of working cat. The general effect is that of a strongly built, well balanced, symmetrical cat with conformation indicating power, endurance, and agility.",
                BreedImageUrl = "https://petaversestorageaccount.blob.core.windows.net/cat-breeds/AmericanShortHair.png",
                Coat = WikiPageCoatEnum.Short,
                Energy = WikiPageEnergyEnum.Medium,
                SheddingLevel = WikiPageSheddingLevelEnum.Medium,
                Size = WikiPageSizeEnum.Small,
            });

            listOfCats.Add(new BreedCardModel()
            {
                BreedName = "American Wirehair",
                BreedDetail = "The distinctive feature of the American Curl is their attractive, uniquely curled-back ears. Elegant, well balanced, moderately muscled, slender rather than massive in build.  They often appear well proportioned and balanced and can vary in size.",
                BreedImageUrl = "https://i.imgur.com/IpeqGBk.png",
                Coat = WikiPageCoatEnum.Long,
                Energy = WikiPageEnergyEnum.Active,
                SheddingLevel = WikiPageSheddingLevelEnum.Heavy,
                Size = WikiPageSizeEnum.Medium
            });

            listOfDogs.Add(new BreedCardModel()
            {
                BreedName = "Golden Retriever",
                BreedDetail = "The Golden Retriever is a sturdy, muscular dog of medium size, famous for the dense, lustrous coat of gold that gives the breed its name. The broad head, with its friendly and intelligent eyes, short ears, and straight muzzle, is a breed hallmark.",
                BreedImageUrl = new Uri("https://i.imgur.com/LYV4FQj.png"),
                Coat = WikiPageCoatEnum.Long,
                Energy = WikiPageEnergyEnum.Medium,
                SheddingLevel = WikiPageSheddingLevelEnum.Heavy,
                Size = WikiPageSizeEnum.XLarge
            });

            listOfSpecies.Add(new SpeciesPivotModel() { SpeciesId = "1", SpeciesName = "Cat", SpeciesImageUrl = "https://i.imgur.com/BhXNGWm.png", BreedCards = listOfCats });
            listOfSpecies.Add(new SpeciesPivotModel() { SpeciesId = "2", SpeciesName = "Dog", SpeciesImageUrl = "https://i.imgur.com/LYV4FQj.png", BreedCards = listOfDogs });
            return listOfSpecies.AsEnumerable();
        });
    }
}
