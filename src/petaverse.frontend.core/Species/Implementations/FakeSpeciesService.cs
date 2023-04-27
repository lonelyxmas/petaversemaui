using Bogus;

namespace petaverse.frontend.core;

public class FakeSpeciesService : ISpeciesService
{
    public Task<IEnumerable<Species>> GetSpecies()
        => Task.Run(() =>
        {
            var faker = new Faker();
            var listOfSpecies = new List<Species>();

            var listOfCats = new List<Breed>();
            var listOfDogs = new List<Breed>();

            listOfCats.Add(new Breed()
            {
                BreedName = "Tabby",
                BreedDescription = "A tabby is any domestic cat with a distinctive 'M'-shaped marking on its forehead; stripes by its eyes and across its cheeks, along its back, and around its legs and tail; and, characteristic striped, dotted, lined, flecked, banded, or swirled patterns on the body—neck, shoulders, sides, flanks, chest, and abdomen.",
                ImageUrl = "https://petaversestorageaccount.blob.core.windows.net/cat-breeds/Tabby.png",
                Coat = CoatEnum.Medium,
                Energy = EnergyEnum.Hunter,
                SheddingLevel = SheddingLevelEnum.Heavy,
                Size = SizeEnum.Medium,
                Colors = "#ffcd43, #e09f00, #2d2c2c"
            });

            listOfCats.Add(new Breed()
            {
                BreedName = "Abyssinian",
                BreedDescription = "The Abyssinian is a breed of domestic short-haired cat with a distinctive \"ticked\" tabby coat, in which individual hairs are banded with different colors. They are also known simply as Abys.",
                ImageUrl = "https://petaversestorageaccount.blob.core.windows.net/cat-breeds/Abyssinian.png",
                Coat = CoatEnum.Medium,
                Energy = EnergyEnum.Hunter,
                SheddingLevel = SheddingLevelEnum.Heavy,
                Size = SizeEnum.Medium,
                Colors = "#ffcd43, #e09f00, #2d2c2c"
            });

            listOfCats.Add(new Breed()
            {
                BreedName = "Persian",
                BreedDescription = "The Persian is a heavily boned, well-balanced cat with a sweet expression and soft, round lines. This cat has large round eyes set wide apart in a large round head. The long thick coat softens the lines of the cat and accentuates the roundness in appearance.",
                ImageUrl = "https://petaversestorageaccount.blob.core.windows.net/cat-breeds/Persian.png",
                Coat = CoatEnum.Long,
                Energy = EnergyEnum.Low,
                SheddingLevel = SheddingLevelEnum.Heavy,
                Size = SizeEnum.Medium,
                Colors = "#f5f5f5"
            });

            listOfCats.Add(new Breed()
            {
                BreedName = "Turkish Angora",
                BreedDescription = "A balanced, graceful cat with a fine, silky coat that shimmers with every movement, in contrast to the firm, long muscular body beneath it.",
                ImageUrl = "https://petaversestorageaccount.blob.core.windows.net/cat-breeds/TurkishAngora.png",
                Coat = CoatEnum.Long,
                Energy = EnergyEnum.Medium,
                SheddingLevel = SheddingLevelEnum.Heavy,
                Size = SizeEnum.Medium,
                Colors = "#ffffff"
            });

            listOfCats.Add(new Breed()
            {
                BreedName = "American Short Hair",
                BreedDescription = "The American Shorthair is a true breed of working cat. The general effect is that of a strongly built, well balanced, symmetrical cat with conformation indicating power, endurance, and agility.",
                ImageUrl = "https://petaversestorageaccount.blob.core.windows.net/cat-breeds/AmericanShortHair.png",
                Coat = CoatEnum.Short,
                Energy = EnergyEnum.Medium,
                SheddingLevel = SheddingLevelEnum.Medium,
                Size = SizeEnum.Small,
                Colors = "#62534e, #694f42, #010602"
            });

            listOfCats.Add(new Breed()
            {
                BreedName = "American Wirehair",
                BreedDescription = "The distinctive feature of the American Curl is their attractive, uniquely curled-back ears. Elegant, well balanced, moderately muscled, slender rather than massive in build.  They often appear well proportioned and balanced and can vary in size.",
                ImageUrl = "https://i.imgur.com/IpeqGBk.png",
                Coat = CoatEnum.Long,
                Energy = EnergyEnum.Active,
                SheddingLevel = SheddingLevelEnum.Heavy,
                Size = SizeEnum.Medium,
                Colors = "#dbd8df"
            });

            listOfDogs.Add(new Breed()
            {
                BreedName = "Golden Retriever",
                BreedDescription = "The Golden Retriever is a sturdy, muscular dog of medium size, famous for the dense, lustrous coat of gold that gives the breed its name. The broad head, with its friendly and intelligent eyes, short ears, and straight muzzle, is a breed hallmark.",
                ImageUrl = "https://i.imgur.com/LYV4FQj.png",
                Coat = CoatEnum.Long,
                Energy = EnergyEnum.Medium,
                SheddingLevel = SheddingLevelEnum.Heavy,
                Size = SizeEnum.XLarge,
                Colors = "#ffcd43, #e09f00, #2d2c2c"
            });

            listOfSpecies.Add(new Species() { Id = 1, Name = "Cat", FrontEndIcon = "cat.png", TopLovedPetOfTheWeek = "https://i.imgur.com/BhXNGWm.png", Breeds = listOfCats });
            listOfSpecies.Add(new Species() { Id = 2, Name = "Dog", FrontEndIcon = "dog.png", TopLovedPetOfTheWeek = "https://i.imgur.com/LYV4FQj.png", Breeds = listOfDogs });
            return listOfSpecies.AsEnumerable();
        });

    public Task<Species> GetSpeciesById(string speciesId)
    {
        throw new NotImplementedException();
    }
}
