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
                BreedDetail = faker.Lorem.Text(),
                BreedImageUrl = "https://petaversestorageaccount.blob.core.windows.net/cat-breeds/Tabby.png"
            });

            listOfCats.Add(new BreedCardModel()
            {
                BreedName = "Abyssinian",
                BreedDetail = faker.Lorem.Text(),
                BreedImageUrl = new Uri("https://petaversestorageaccount.blob.core.windows.net/cat-breeds/Abyssinian.png")
            });

            listOfCats.Add(new BreedCardModel()
            {
                BreedName = "Persian",
                BreedDetail = faker.Lorem.Text(),
                BreedImageUrl = new Uri("https://petaversestorageaccount.blob.core.windows.net/cat-breeds/Persian.png")
            });

            listOfCats.Add(new BreedCardModel()
            {
                BreedName = "Turkish Angora",
                BreedDetail = faker.Lorem.Text(),
                BreedImageUrl = "https://petaversestorageaccount.blob.core.windows.net/cat-breeds/TurkishAngora.png"
            });

            listOfCats.Add(new BreedCardModel()
            {
                BreedName = "American Short Haird",
                BreedDetail = faker.Lorem.Text(),
                BreedImageUrl = "https://petaversestorageaccount.blob.core.windows.net/cat-breeds/AmericanShortHair.png"
            });

            listOfDogs.Add(new BreedCardModel()
            {
                BreedName = "Golden Retriever",
                BreedImageUrl = new Uri("https://i.imgur.com/LYV4FQj.png")
            });


            listOfSpecies.Add(new SpeciesPivotModel() { SpeciesName = "Dog", SpeciesImageUrl = "https://i.imgur.com/LYV4FQj.png", BreedCards = listOfDogs });
            listOfSpecies.Add(new SpeciesPivotModel() { SpeciesName = "Cat", SpeciesImageUrl = "https://i.imgur.com/BhXNGWm.png", BreedCards = listOfCats });
            return listOfSpecies.AsEnumerable();
        });
    }
}
