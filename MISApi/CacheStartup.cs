using MISApi.Entities.WFM;

namespace MISApi
{
    /// <summary>
    /// 
    /// </summary>
    public class CacheStartup
    {
        /// <summary>
        /// 
        /// </summary>
        public CacheStartup()
        {
            Status.Instance.CacheAll();
        }
    }
}
