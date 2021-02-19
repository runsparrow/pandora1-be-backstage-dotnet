using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace MISApi.HttpClients.HttpModes.ColumnsMode
{
    /// <summary>
    /// 
    /// </summary>
    public class Request<T>
    {
        /// <summary>
        /// Service中的方法
        /// </summary>
        [JsonProperty(PropertyName = "function")]
        public virtual BaseMode.Function Function { get; set; } = new BaseMode.Function();
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "pluginConfig")]
        public Config PluginConfig { get; set; } = new Config();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual Response<T> ToResponse(T entity)
        {
            Response<T> response = new Response<T>();
            response.Request = this;
            response.Entity = entity;
            return response;
        }

        #region Config 内部类
        /// <summary>
        /// 
        /// </summary>
        public class Config
        {
            /// <summary>
            /// 
            /// </summary>
            [JsonIgnore]
            public string Plugin { get; } = "DefaultTable";
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "firstCheckbox")]
            public bool FirstCheckbox { get; set; } = true;
        }
        #endregion
    }
    /// <summary>
    /// 
    /// </summary>
    public class Response<T>
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "request")]
        public virtual Request<T> Request { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "entity")]
        public virtual T Entity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "columns")]
        public virtual List<IColumnBase> Columns
        {
            get
            {
                return ToColumns(Activator.CreateInstance<T>(), Request.PluginConfig);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="requestConfig"></param>
        /// <returns></returns>
        public virtual List<IColumnBase> ToColumns(T entity, Request<T>.Config requestConfig)
        {
            List<IColumnBase> columnList = new List<IColumnBase>();
            PropertyInfo[] properties = entity.GetType().GetProperties();
            if (requestConfig.FirstCheckbox)
            {
                IColumnBase column = (IColumnBase)Activator.CreateInstance(Type.GetType("MISApi.HttpClients.HttpModes.ColumnsMode." + requestConfig.Plugin), true);
                column.Checkbox = true;
                columnList.Add(column);
            }
            foreach (PropertyInfo p in properties)
            {
                IColumnBase column = (IColumnBase)Activator.CreateInstance(Type.GetType("MISApi.HttpClients.HttpModes.ColumnsMode." + requestConfig.Plugin), true);
                column.Field = p.Name;

                DescriptionAttribute[] desc = (DescriptionAttribute[])p.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (desc.Length > 0)
                    column.Title = desc[0].Description;
                else
                    column.Title = p.Name;
                columnList.Add(column);
            }
            return columnList;
        }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "error")]
        public virtual string Error { get; set; }

    }
}