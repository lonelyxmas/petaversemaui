using System.Collections.Generic;

namespace PetaverseMAUI;

public class FakeWikiService : IWikiService
{
    //public Task<List<SpeciesPivotModel>> GetAll()
    //{
    //    //return Task.Run(() =>
    //    //{
    //    //    var faker = new Faker<BreedCardModel>();
    //    //    faker.RuleFor(x => x.BreedName, setter => "Tabby");
    //    //    faker.RuleFor(x => x.BreedDetail, setter => setter.Lorem.Text());


    //    //    return faker.Generate(10).ToList();
    //    //});
    //}

    public Task<IEnumerable<SpeciesPivotModel>> GetAllSpecies()
    {

        return Task.Run(() =>
        {
            var faker = new Faker();
            var listOfSpecies = new List<SpeciesPivotModel>();

            var listOfCats = new ObservableCollection<BreedCardModel>();
            var listOfDogs = new ObservableCollection<BreedCardModel>();

            listOfCats.Add(new BreedCardModel()
            {
                BreedName = "Tabby",
                BreedDetail = "A tabby is any domestic cat with a distinctive 'M'-shaped marking on its forehead; stripes by its eyes and across its cheeks, along its back, and around its legs and tail; and, characteristic striped, dotted, lined, flecked, banded, or swirled patterns on the body—neck, shoulders, sides, flanks, chest, and abdomen.",
                BreedImageUrl = "https://petaversestorageaccount.blob.core.windows.net/cat-breeds/Tabby.png"
            });

            listOfCats.Add(new BreedCardModel()
            {
                BreedName = "Abyssinian",
                BreedDetail = "The Abyssinian is a breed of domestic short-haired cat with a distinctive \"ticked\" tabby coat, in which individual hairs are banded with different colors. They are also known simply as Abys.",
                BreedImageUrl = new Uri("https://petaversestorageaccount.blob.core.windows.net/cat-breeds/Abyssinian.png")
            });

            listOfCats.Add(new BreedCardModel()
            {
                BreedName = "Persian",
                BreedDetail = "The Persian is a heavily boned, well-balanced cat with a sweet expression and soft, round lines. This cat has large round eyes set wide apart in a large round head. The long thick coat softens the lines of the cat and accentuates the roundness in appearance.",
                BreedImageUrl = new Uri("https://petaversestorageaccount.blob.core.windows.net/cat-breeds/Persian.png")
            });

            listOfCats.Add(new BreedCardModel()
            {
                BreedName = "Turkish Angora",
                BreedDetail = "A balanced, graceful cat with a fine, silky coat that shimmers with every movement, in contrast to the firm, long muscular body beneath it.",
                BreedImageUrl = "https://petaversestorageaccount.blob.core.windows.net/cat-breeds/TurkishAngora.png"
            });

            listOfCats.Add(new BreedCardModel()
            {
                BreedName = "American Short Haird",
                BreedDetail = "The American Shorthair is a true breed of working cat. The general effect is that of a strongly built, well balanced, symmetrical cat with conformation indicating power, endurance, and agility.",
                BreedImageUrl = "https://petaversestorageaccount.blob.core.windows.net/cat-breeds/AmericanShortHair.png"
            });

            listOfCats.Add(new BreedCardModel()
            {
                BreedName = "American Wirehair",
                BreedDetail = "The distinctive feature of the American Curl is their attractive, uniquely curled-back ears. Elegant, well balanced, moderately muscled, slender rather than massive in build.  They often appear well proportioned and balanced and can vary in size.",
                BreedImageUrl = "https://i.imgur.com/IpeqGBk.png"
            });

            listOfDogs.Add(new BreedCardModel()
            {
                BreedName = "Golden Retriever",
                BreedDetail = "The Golden Retriever is a sturdy, muscular dog of medium size, famous for the dense, lustrous coat of gold that gives the breed its name. The broad head, with its friendly and intelligent eyes, short ears, and straight muzzle, is a breed hallmark.",
                BreedImageUrl = new Uri("https://i.imgur.com/LYV4FQj.png")
            });

            listOfSpecies.Add(new SpeciesPivotModel() { SpeciesName = "Cat", SpeciesImageUrl = "https://i.imgur.com/BhXNGWm.png", BreedCards = listOfCats });
            listOfSpecies.Add(new SpeciesPivotModel() { SpeciesName = "Dog", SpeciesImageUrl = "https://i.imgur.com/LYV4FQj.png", BreedCards = listOfDogs });
            return listOfSpecies.AsEnumerable();
        });
    }
}
