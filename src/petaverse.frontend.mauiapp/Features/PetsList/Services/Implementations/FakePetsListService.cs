﻿using Bogus;

namespace petaverse.frontend.mauiapp;

public class FakePetListService : IPetsListService
{
    public Task<IEnumerable<PetProfileCardModel>> GetAll()
    {
        return Task.Run(() =>
        {
            var faker = new Faker<PetProfileCardModel>();
            faker.RuleFor(x => x.Name, setter => setter.Person.FirstName);
            faker.RuleFor(x => x.Breed, (f, model) => new Breed() { BreedName = f.PickRandom("Tabby", "Husky") });
            faker.RuleFor(x => x.MediaCount, setter => setter.Random.Number(1000));
            faker.RuleFor(x => x.SpeciesType, (f, model) => f.PickRandom(SpeciesType.Cat, SpeciesType.Dog, SpeciesType.Fish));
            faker.RuleFor(x => x.ProfileUrl, (f, model) => f.Image.LoremFlickrUrl(120, 120, model.SpeciesType == SpeciesType.Cat ? "cat"
                                                                                                                                 : model.SpeciesType == SpeciesType.Dog ? "dog"
                                                                                                                                                                        : "fish"));
            return faker.Generate(10).AsEnumerable();
        });
    }
}
