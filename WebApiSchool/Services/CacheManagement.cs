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
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public void Set(string key, object value, TimeSpan? timeSpan = null)
        {
            throw new NotImplementedException();
        }
    }
}
