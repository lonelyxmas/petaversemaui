namespace petaverse.frontend.core;

public class User : BaseEntity
{
    public string? PetaverseProfileImageUrl { get; set; }
    public string? CoverImageUrl { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool? IsActive { get; set; }
    public bool IsDeleted { get; set; } = false;
}
