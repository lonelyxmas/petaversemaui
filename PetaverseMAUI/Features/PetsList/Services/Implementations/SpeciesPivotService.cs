namespace PetaverseMAUI;

public class SpeciesPivotService : ISpeciesPivotService
{
    public Task<List<SpeciesPivotModel>> GetAllSpecies()
    {
        return Task.Run(() =>
        {
            var listOfSpecies = new List<SpeciesPivotModel>();
            listOfSpecies.Add(new SpeciesPivotModel() { SpeciesName = "Cat", SpeciesImageUrl = "https://i.imgur.com/BhXNGWm.png" });
            listOfSpecies.Add(new SpeciesPivotModel() { SpeciesName = "Dog", SpeciesImageUrl = "https://i.imgur.com/LYV4FQj.png" });
            return listOfSpecies;
        });
    }
}
