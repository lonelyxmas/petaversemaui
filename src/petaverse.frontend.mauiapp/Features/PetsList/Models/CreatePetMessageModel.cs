namespace petaverse.frontend.mauiapp;

public record CreatePetMessageModel(string? petName,
                                    string? petAvatarUrl,
                                    string? bio,
                                    string? petColors,
                                    string? sixDigitCode,
                                    bool? gender,
                                    double? age,
                                    DateTime? dateOfBirth,
                                    string? breedName,
                                    string? breedDescription,
                                    string? breedColors,
                                    string? speciesName,
                                    string? speciesDescription);
