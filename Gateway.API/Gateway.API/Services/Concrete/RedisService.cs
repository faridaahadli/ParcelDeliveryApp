using Gateway.API.Services.Abstract;
using StackExchange.Redis;

namespace Gateway.API.Services.Concrete
{
    public class RedisService:IRedisService
    {
        private readonly IDatabase _db;
      
        public RedisService(IConnectionMultiplexer redis)
        {
            _db=redis.GetDatabase();
        }

      
        public string Get(string key)
        {
            return _db.StringGet(key);
        }

     
        public async Task PushList(string key, string data)
        {
            await _db.ListRightPushAsync(key, data);
        }
        public async Task<string> PopList(string key)
        {
            return await _db.ListLeftPopAsync(key);
        }
        public async Task<bool> DeleteKey(string key)
        {
            return await _db.KeyDeleteAsync(key);
        }
        public async Task<bool> CheckKey(string key)
        {
            return await _db.KeyExistsAsync(key);
        }
    }
}
