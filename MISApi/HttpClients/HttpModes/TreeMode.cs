using Newtonsoft.Json;
using System.Collections.Generic;

namespace MISApi.HttpClients.HttpModes.TreeMode
{
    #region Request

    #region Base Request
    /// <summary>
    /// 
    /// </summary>
    public class Request<T> : RowsMode.Request<T>
    {
        #region Request 属性


        #endregion

        #region Request 方法

        #endregion
    }
    #endregion

    #region BootstrapTreeViewRequest
    /// <summary>
    /// 
    /// </summary>
    public class BootstrapTreeViewRequest<T> : Request<T>
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "config")]
        public virtual BootstrapTreeView.Config<T> Config { get; set; } = new BootstrapTreeView.Config<T>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <returns></returns>
        public new virtual BootstrapTreeViewResponse<T> ToResponse(List<T> rows)
        {
            BootstrapTreeViewResponse<T> response = new BootstrapTreeViewResponse<T>();
            response.Request = this;
            response.Rows = rows;
            return response;
        }
    }
    #endregion

    #region AntdTreeRequest
    /// <summary>
    /// 
    /// </summary>
    public class AntdTreeRequest<T> : Request<T>
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "config")]
        public virtual AntdTree.Config<T> Config { get; set; } = new AntdTree.Config<T>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <returns></returns>
        public new virtual AntdTreeResponse<T> ToResponse(List<T> rows)
        {
            AntdTreeResponse<T> response = new AntdTreeResponse<T>();
            response.Request = this;
            response.Rows = rows;
            return response;
        }
    }
    #endregion

    #endregion

    #region Response

    #region Base Response
    /// <summary>
    /// 
    /// </summary>
    public class Response<T>
    {
        #region Response 属性
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "request")]
        public virtual Request<T> Request { get; set; } = new Request<T>();
        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        [JsonProperty(PropertyName = "rows")]
        public virtual List<T> Rows { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "error")]
        public virtual string Error { get; set; }
        #endregion
    }
    #endregion

    #region BootstrapTreeViewResponse
    /// <summary>
    /// 
    /// </summary>
    public class BootstrapTreeViewResponse<T> : Response<T>
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "request")]
        public new virtual BootstrapTreeViewRequest<T> Request { get; set; } = new BootstrapTreeViewRequest<T>();
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "tree")]
        public virtual List<BootstrapTreeView.Node> Tree
        {
            get
            {
                return new BootstrapTreeView.TreeViewBase<T>().ToTree(Rows, Request.Config);
            }
        }

    }
    #endregion

    #region AntdTreeResponse
    /// <summary>
    /// 
    /// </summary>
    public class AntdTreeResponse<T> : Response<T>
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "request")]
        public new virtual AntdTreeRequest<T> Request { get; set; } = new AntdTreeRequest<T>();
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "tree")]
        public virtual List<AntdTree.Child> Tree
        {
            get
            {
                return new AntdTree.TreeViewBase<T>().ToTree(Rows, Request.Config);
            }
        }

    }
    #endregion

    #endregion
}