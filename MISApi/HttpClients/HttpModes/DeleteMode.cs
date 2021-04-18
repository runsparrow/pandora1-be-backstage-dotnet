using Newtonsoft.Json;
using System.Collections.Generic;

namespace MISApi.HttpClients.HttpModes.DeleteMode
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

    /// <summary>
    /// 
    /// </summary>
    public class Log
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "userId")]
        public virtual int UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "employeeId")]
        public virtual int EmployeeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "userName")]
        public virtual string UserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "employeeName")]
        public virtual string EmployeeName { get; set; }
    }
}