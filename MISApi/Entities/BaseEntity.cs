using System;

namespace MISApi.Entities
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public abstract class BaseEntity<T>
        where T : class, new()
    {

    }
}