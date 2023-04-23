using System.Threading.Tasks;

namespace PetaverseMAUI;

public class CreateSpecisService : IWikiCreateService
{
    public Task<List<Breed>> GetBySpeciesTypeAsync(SpeciesType speciesType)
    {
        var Cat = new List<Breed>();
        var Dog = new List<Breed>();

        Cat.Add(new Breed {Id = "1", Name = "Abyssinian"});
        Cat.Add(new Breed {Id = "2", Name = "American Bobtail"});
        Cat.Add(new Breed {Id = "3", Name = "American Curl" });
        Cat.Add(new Breed {Id = "4", Name = "American Shorthair"});
        Cat.Add(new Breed {Id = "5", Name = "American Wirehair"});
        Cat.Add(new Breed {Id = "6", Name = "Balinese-Javanese"});
        Cat.Add(new Breed {Id = "7", Name = "Bengal"});
        Cat.Add(new Breed {Id = "8", Name = "Myanmar"});
        Cat.Add(new Breed {Id = "9", Name = "Bombay"});
        Cat.Add(new Breed {Id = "10", Name = "British Shorthair "});
        Cat.Add(new Breed {Id = "11", Name = "Burmese"});
        Cat.Add(new Breed {Id = "12", Name = "Cornish Rex"});
        Cat.Add(new Breed {Id = "13", Name = "Devon Rex"});
        Cat.Add(new Breed {Id = "14", Name = "Egyptian Mau"});
        Cat.Add(new Breed {Id = "15", Name = "European Burmese"});

        Dog.Add(new Breed {Id = "1", Name = "Giant Schnauzer"});
        Dog.Add(new Breed {Id = "2", Name = "Glen of Imaal Terrier"});
        Dog.Add(new Breed {Id = "3", Name = "Golden Retriever"});
        Dog.Add(new Breed {Id = "4", Name = "Gordon Setter"});
        Dog.Add(new Breed {Id = "5", Name = "Great Dane"});
        Dog.Add(new Breed {Id = "6", Name = "Great Pyrenees"});
        Dog.Add(new Breed {Id = "7", Name = "Greater Swiss Mountain Dog"});
        Dog.Add(new Breed {Id = "8", Name = "Greyhound"});
        Dog.Add(new Breed {Id = "9", Name = "Harrier"});
        Dog.Add(new Breed {Id = "10", Name = "Havanese"});
        Dog.Add(new Breed {Id = "11", Name = "Ibizan Hound"});
        Dog.Add(new Breed {Id = "12", Name = "Icelandic Sheepdog"});
        Dog.Add(new Breed {Id = "13", Name = "Affenpinscher"});
        Dog.Add(new Breed {Id = "14", Name = "Afghan Hound"});
        Dog.Add(new Breed {Id = "15", Name = "Airedale Terrier"});

        if (speciesType.Equals(SpeciesType.Cat))
        {
            return Task.FromResult(Cat);
        }

        if (speciesType.Equals(SpeciesType.Dog))
        {
            return Task.FromResult(Dog);
        }

        return Task.FromResult(new List<Breed>());
    }
}
