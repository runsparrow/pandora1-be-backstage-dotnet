using Newtonsoft.Json;
using System.Collections.Generic;

namespace MISApi.HttpClients.HttpModes.UpdateMode
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
            List<T> entities = new List<T>();
            entities.Add(entity);
            return ToResponse(entities);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
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
        public virtual Response<T> ToResponse(bool result)
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
        public virtual bool Result { get; set; } = true;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public virtual string Message { get; set; } = "";
    }
}