using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SelamYemek.Caching.Base
{
    public interface IRedisOperation
    {
        T Get<T>(Func<T> func, string key);
    }
}
