using Newtonsoft.Json;
using System.Collections.Generic;

namespace MISApi.HttpClients.HttpModes.RowsMode
{
    /// <summary>
    /// 
    /// </summary>
    public class Request<T>
    {
        /// <summary>
        /// keyWord
        /// </summary>
        [JsonProperty(PropertyName = "keyWord")]
        public virtual BaseMode.KeyWord KeyWord { get; set; } = new BaseMode.KeyWord();
        /// <summary>
        /// page
        /// </summary>
        [JsonProperty(PropertyName = "page")]
        public virtual BaseMode.Page Page { get; set; } = new BaseMode.Page();
        /// <summary>
        /// sort
        /// </summary>
        [JsonProperty(PropertyName = "sorts")]
        public virtual BaseMode.Sort[] Sorts { get; set; } = new BaseMode.Sort[] { };
        /// <summary>
        /// joins
        /// </summary>
        [JsonProperty(PropertyName = "joins")]
        public virtual BaseMode.Join[] Joins { get; set; } = new BaseMode.Join[] { };
        /// <summary>
        /// dates
        /// </summary>
        [JsonProperty(PropertyName = "dates")]
        public virtual BaseMode.Date[] Dates { get; set; } = new BaseMode.Date[] { };
        /// <summary>
        /// status
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public virtual BaseMode.Status Status { get; set; } = new BaseMode.Status();
        /// <summary>
        /// Service中的方法
        /// </summary>
        [JsonProperty(PropertyName = "function")]
        public virtual BaseMode.Function Function { get; set; } = new BaseMode.Function();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual Response<T> ToResponse(List<T> entities)
        {
            Response<T> response = new Response<T>();
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