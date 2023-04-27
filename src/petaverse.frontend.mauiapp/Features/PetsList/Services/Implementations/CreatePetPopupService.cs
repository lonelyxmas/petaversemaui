using AutoMapper;

namespace petaverse.frontend.mauiapp;

internal class CreatePetPopupService : ICreatePetPopupService
{
    #region [ Fields ]
    private readonly IMapper _mapper;
    private readonly ISpeciesService _speciesService;
    #endregion

    #region [ CTor ]
    public CreatePetPopupService(IMapper mapper,
                                     ISpeciesService speciesService)
    {
        _mapper = mapper;
        _speciesService = speciesService;
    }
    #endregion

    #region [ Methods ]

    public async Task<IEnumerable<CreatePetPopupSpeciesModel>> GetSpecies()
    {
        var result = await _speciesService.GetSpecies();
        return _mapper.Map<IEnumerable<CreatePetPopupSpeciesModel>>(result);
    }
    #endregion
}
