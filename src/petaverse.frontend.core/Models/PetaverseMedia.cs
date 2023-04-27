namespace petaverse.frontend.core;

public class PetaverseMedia : BaseEntity
{
    public string MediaName { get; set; } = string.Empty;
    public string MediaUrl { get; set; } = string.Empty;
    public DateTime TimeUpload { get; set; } = DateTime.UtcNow;
    public MediaTypeEnum Type { get; set; }


    public virtual ICollection<AnimalPetaverseMedia> AnimalPetaverseMedias { get; set; } = new HashSet<AnimalPetaverseMedia>();
}