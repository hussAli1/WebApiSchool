using Microsoft.Extensions.Caching.Memory;
using WebApiSchool.MyLogger;
using WebApiSchool.Services.Interfaces;

namespace WebApiSchool.Services
{
    public class CacheManagement : ICacheManagement
    {
        private readonly ILoggerManager _logger;
        private readonly IMemoryCache _memoryCache;

        public CacheManagement(ILoggerManager logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            _memoryCache = memoryCache;
        }
        public object Get(string key)
        {
            try
            {
                _memoryCache.TryGetValue(key, out object obj);
                return obj;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "CacheManagement", "GetCache");
                return default;
            }
        }

        public void Remove(string key)
        {
            try
            {
                _memoryCache.Remove(key);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "CacheManagement", "RemoveCache");
            }
        }

        public void Set(string key, object value, TimeSpan? timeSpan = null)
        {
            try
            {
                if (timeSpan == null)
                {
                    timeSpan = TimeSpan.FromHours(3);
                }

                _memoryCache.Set(key, value, (TimeSpan)timeSpan);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "CacheManagement", "SetCache");
            }
        }
    }
}
