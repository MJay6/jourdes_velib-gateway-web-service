using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace IWS_VelibWS
{
    class MonitorService : IMonitorService
    {
        public int GetCacheExpirationTime()
        {
            return Service.cacheExpirationTime;
        }

        public int GetNbCacheRequest()
        {
            return Service.nbCacheRequest;
        }

        public int GetNbRequest()
        {
            return Service.nbRequest;
        }

        public int SetCacheExpirationTime(int time)
        {
            Service.cacheExpirationTime = time;
            return time;
        }

        public string[] GetCachedCities()
        {
            string[] cachedCities = new string[Service.cache.GetCount()];
            int i = 0;
            foreach (KeyValuePair<string,object> item in Service.cache.AsEnumerable())
            {
                cachedCities[i] = item.Key;
                i++;
            }
            return cachedCities;
        }
    }
}
