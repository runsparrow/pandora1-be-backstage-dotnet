using Newtonsoft.Json;

namespace MISApi.HttpClients.HttpModes.RowMode
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
        /// 是否夺标关联
        /// </summary>
        [JsonProperty(PropertyName = "joins")]
        public virtual BaseMode.Join[] Joins { get; set; } = new BaseMode.Join[] { };
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual Response<T> ToResponse(T entity)
        {
            Response<T> response = new Response<T>();
            response.Row = entity;
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
        [JsonProperty(PropertyName = "row")]
        public virtual T Row { get; set; }
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