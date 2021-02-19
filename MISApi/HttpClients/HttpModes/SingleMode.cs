using Newtonsoft.Json;

namespace MISApi.HttpClients.HttpModes.SingleMode
{
    /// <summary>
    /// 
    /// </summary>
    public class Request<T> : RowMode.Request<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public new virtual Response<T> ToResponse(T entity)
        {
            Response<T> response = new Response<T>();
            response.Request = this;
            response.Row = entity;
            return response;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Response<T> : RowMode.Response<T>
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "request")]
        public virtual Request<T> Request { get; set; }
    }
}