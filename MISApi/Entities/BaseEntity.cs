using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MISApi.Entities
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public abstract class BaseEntity<T>
        where T : class, new()
    {
        /// <summary>
        /// 为实体设置默认值【只对Null值的Property产生效果】
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T DefaultValue(T entity)
        {
            PropertyInfo[] properties = entity.GetType().GetProperties();
            foreach (var p in properties)
            {
                var entityValue = p.GetValue(entity, null);
                // 输入值不等于null
                if (entityValue == null)
                {
                    // 如果是DateTime类型，特性 [DefaultValue(typeof(DateTime), "0001-01-01")]取ConstructorArguments第二个参数
                    if (p.PropertyType.FullName.Contains("System.DateTime"))
                    {
                        p.SetValue(entity, DateTime.Parse(p.CustomAttributes.ToList().Find(row => row.AttributeType.Name == "DefaultValueAttribute")?.ConstructorArguments[1].Value.ToString()), null);
                    }
                    // 如果是decimal类型，特性 [DefaultValue(typeof(Decimal), "0")]取ConstructorArguments第二个参数
                    else if (p.PropertyType.FullName.Contains("System.Decimal"))
                    {
                        p.SetValue(entity, decimal.Parse(p.CustomAttributes.ToList().Find(row => row.AttributeType.Name == "DefaultValueAttribute")?.ConstructorArguments[1].Value.ToString()), null);
                    }
                    else
                    {
                        p.SetValue(entity, p.CustomAttributes.ToList().Find(row => row.AttributeType.Name == "DefaultValueAttribute")?.ConstructorArguments[0].Value, null);
                    }
                }
            }
            return entity;
        }
    }
}