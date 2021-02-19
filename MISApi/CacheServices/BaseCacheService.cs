using MISApi.Services;
using Microsoft.EntityFrameworkCore;

namespace MISApi.CacheServices
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseCacheService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TContext"></typeparam>
        public abstract class EF<T, TContext> : BaseService.EF<T, TContext>
            where T : class, new()
            where TContext : DbContext, new()
        {

        }
    }

}