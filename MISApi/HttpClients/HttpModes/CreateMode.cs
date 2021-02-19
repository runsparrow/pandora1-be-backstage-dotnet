using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;

namespace MISApi.HttpClients.HttpModes.CreateMode
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
        public virtual BaseMode.Function Function { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "entity")]
        public virtual T Entity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "entities")]
        public virtual List<T> Entities { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual Response<T> ToResponse(T entity)
        {
            Response<T> response = new Response<T>();
            response.Request = this;
            response.Row = entity;
            return response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual Response<T> ToResponse(List<T> entities)
        {
            Response<T> response = new Response<T>();
            response.Request = this;
            response.Rows = entities;
            return response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public virtual Response<T> ToResponse(int result)
        {
            Response<T> response = new Response<T>();
            response.Request = this;
            response.Result = result;
            return response;
        }
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
        [JsonProperty(PropertyName = "row")]
        public virtual T Row { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "rows")]
        public virtual List<T> Rows { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "result")]
        public virtual int Result { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "error")]
        public virtual string Error { get; set; }
    }
}