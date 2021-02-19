using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace MISApi.HttpClients.HttpModes.QueryMode
{
    /// <summary>
    /// 
    /// </summary>
    public class Request<T> : RowsMode.Request<T>
    {
        /// <summary>
        /// 使用于client端的分页，即实体类集合结果数作为total变量
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public new virtual Response<T> ToResponse(List<T> entities)
        {
            Response<T> response = new Response<T>();
            response.Request = this;
            response.Total = entities.Count();
            response.Rows = entities;
            return response;
        }
        /// <summary>
        ///  使用于server端的分页，也就是实体类集合只返回当页数据，total是同查询条件的查询结果数
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public virtual Response<T> ToResponse(List<T> entities, int total)
        {
            Response<T> response = new Response<T>();
            response.Request = this;
            response.Total = total;
            response.Rows = entities;
            return response;
        }
        /// <summary>
        ///  使用于server端的分页，也就是实体类集合只返回当页数据，total是同查询条件的查询结果数
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="total"></param>
        /// <param name="summary"></param>
        /// <returns></returns>
        public virtual Response<T> ToResponse(List<T> entities, int total, dynamic summary)
        {
            Response<T> response = new Response<T>();
            response.Request = this;
            response.Total = total;
            response.Rows = entities;
            response.Summary = summary;
            return response;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Response<T> : RowsMode.Response<T>
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "request")]
        public virtual Request<T> Request { get; set; }
        /// <summary>
        /// 查询结果总数
        /// </summary>
        [JsonProperty(PropertyName = "total")]
        public int Total { get; set; }
        /// <summary>
        /// 汇总
        /// </summary>
        [JsonProperty(PropertyName = "summary")]
        public dynamic Summary { get; set; }
    }
}