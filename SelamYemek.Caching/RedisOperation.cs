using SelamYemek.Caching.Base;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SelamYemek.Caching
{
    public class RedisOperation : IRedisOperation
    {
        #region Fields
        private readonly IDistributedCache _distributedCache;
        #endregion

        #region Constructors
        public RedisOperation(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
        #endregion

        #region Methods
        public T Get<T>(Func<T> func, string key)
        {
            T t;

            string tJson = string.Empty;
            var data = _distributedCache.Get(key);

            if (data == null)
            {
                t = func();
                if (t == null)
                    return t;

                this.Add(key, t);
            }
            else
            {
                tJson = Encoding.UTF8.GetString(data);
            }

            return JsonConvert.DeserializeObject<T>(tJson);
        }

        private void Add<T>(string key, T value)
        {
            try
            {
                string tJson = JsonConvert.SerializeObject(value);

                var data = Encoding.UTF8.GetBytes(tJson);
                var option = new DistributedCacheEntryOptions().SetAbsoluteExpiration(DateTime.Now.AddMinutes(5));
                _distributedCache.Set(key, data, option);
            }
            catch (Exception)
            {

            }
        }
        #endregion
    }
}
