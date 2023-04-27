using AutoMapper;

namespace petaverse.frontend.mauiapp;

internal class PetsListMappingProfiles : Profile
{
    #region [ CTor ]
    public PetsListMappingProfiles()
    {
        CreateMap<Species, CreatePetPopupSpeciesModel>()
            .ForMember(dest => dest.SpeciesName,
                       opt => opt.MapFrom(src => src.Name));

        CreateMap<Breed, CreatePetPopupBreedModel>()
            .ForMember(dest => dest.BreedName,
                       opt => opt.MapFrom(src => src.BreedName));

        CreateMap<CreatePetMessageModel, PetProfileCardModel>()
            .ForMember(dest => dest.Name,
                       opt => opt.MapFrom(src => src.petName))
            .ForMember(dest => dest.ProfileUrl,
                       opt => opt.MapFrom(src => src.petAvatarUrl))
            .ForMember(dest => dest.Bio,
                       opt => opt.MapFrom(src => src.bio))
            .ForMember(dest => dest.PetColors,
                       opt => opt.MapFrom(src => src.petColors))
            .ForMember(dest => dest.SixDigitCode,
                       opt => opt.MapFrom(src => src.sixDigitCode))
            .ForMember(dest => dest.MediaCount,
                       opt => opt.MapFrom(src => 0))
            .ForMember(dest => dest.BreedName,
                       opt => opt.MapFrom(src => src.breedName)).ForMember(dest => dest.BreedDescription,
                       opt => opt.MapFrom(src => src.breedDescription))
            .ForMember(dest => dest.BreedColors,
                       opt => opt.MapFrom(src => src.breedColors))
            .ForMember(dest => dest.BreedDescription,
                       opt => opt.MapFrom(src => src.breedDescription))
            .ForMember(dest => dest.SpeciesName,
                       opt => opt.MapFrom(src => src.speciesName))
            .ForMember(dest => dest.SpeciesDescription,
                       opt => opt.MapFrom(src => src.speciesDescription));
    }
    #endregion
}
