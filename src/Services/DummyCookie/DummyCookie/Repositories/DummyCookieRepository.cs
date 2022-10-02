using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace DummyCookie.Repositories
{
    public class DummyCookieRepository : IDummyCookieRepository
    {
        private readonly IDistributedCache _redisCache;

        public DummyCookieRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
        }

        public async Task<DummyCookie> GetByName(string userName)
        {
            var cookie = await _redisCache.GetStringAsync(userName);

            if (String.IsNullOrEmpty(cookie)) return null;

            return JsonConvert.DeserializeObject<DummyCookie>(cookie);
        }

        public async Task<DummyCookie> Update(DummyCookie cookie)
        {
            await _redisCache.SetStringAsync(cookie.Name, JsonConvert.SerializeObject(cookie));

            return await GetByName(cookie.Name);
        }

        public async Task Delete(string name)
        {
            await _redisCache.RemoveAsync(name);
        }
    }
}
