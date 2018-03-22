using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
