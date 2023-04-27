namespace petaverse.frontend.mauiapp;

public interface ISecureStorageService
{
    Task WriteValueAsync(string key, string value);

    Task<string> ReadValueAsync(string key);

    Task<bool> RemoveValueAsync(string key);

    Task RemoveAllValueAsync();
}
