using Microsoft.EntityFrameworkCore;
using System;

namespace MISApi.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TContext"></typeparam>
        public abstract class EF<T, TContext> : Dal.EF.BaseDal<T, TContext>
            where T : class
            where TContext : DbContext, new()
        {

        }
    }
}
