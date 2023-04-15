namespace PetaverseMAUI;

public record AuthenticationResponseDTO(string userGuid,
                                        DateTime requestAt,
                                        string accessToken,
                                        double expireIn);
