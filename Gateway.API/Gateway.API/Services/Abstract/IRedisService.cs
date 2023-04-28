namespace Gateway.API.Services.Abstract
{
    public interface IRedisService
    {
        string Get(string key);        
        Task PushList(string key, string data);
        Task<string> PopList(string key);
        Task<bool> DeleteKey(string key);
        Task<bool> CheckKey(string key);
    }
}
