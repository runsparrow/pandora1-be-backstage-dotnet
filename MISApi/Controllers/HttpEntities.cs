using MISApi.HttpClients.HttpModes.TreeMode.BootstrapTreeView;
using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace MISApi.Controllers.HttpEntities
{

    /// <summary>
    /// 
    /// </summary>
    public class DTO_AccountNameAndAccountPwd
    {
        /// <summary>
        /// 账户名
        /// </summary>
        [Description("账户名")]
        [JsonProperty("accountName")]
        public string AccountName { get; set; } = "";
        /// <summary>
        /// 账户密码
        /// </summary>
        [Description("账户密码")]
        [JsonProperty("accountPwd")]
        public string AccountPwd { get; set; } = "";
    }
    /// <summary>
    /// 
    /// </summary>
    public class DTO_Token
    {
        /// <summary>
        /// Token
        /// </summary>
        [Description("Token")]
        [JsonProperty("token")]
        public string Token { get; set; } = "";
    }
    /// <summary>
    /// 
    /// </summary>
    public class DTO_Result
    {
        /// <summary>
        /// 结果
        /// </summary>
        [Description("结果")]
        [JsonProperty("result")]
        public bool Result { get; set; } = false;
        /// <summary>
        /// Token
        /// </summary>
        [Description("Token")]
        [JsonProperty("token")]
        public string Token { get; set; } = "";
        /// <summary>
        /// 用户
        /// </summary>
        [Description("用户")]
        [JsonProperty("userInfo")]
        public DTO_User UserInfo { get; set; } = new DTO_User();
    }
    /// <summary>
    /// 
    /// </summary>
    public class DTO_User
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        [Description("用户Id")]
        [JsonProperty("userId")]
        public int UserId { get; set; } = -1;
        /// <summary>
        /// 用户名
        /// </summary>
        [Description("用户名")]
        [JsonProperty("userName")]
        public string UserName { get; set; } = "";
        /// <summary>
        /// 姓名
        /// </summary>
        [Description("姓名")]
        [JsonProperty("employeeName")]
        public string EmployeeName { get; set; } = "";
    }
    /// <summary>
    /// 
    /// </summary>
    public class DTO_Page
    {
        /// <summary>
        /// 关键字
        /// </summary>
        [Description("关键字")]
        [JsonProperty("keyWord")]
        public string KeyWord { get; set; } = "";
        /// <summary>
        /// 分页
        /// </summary>
        [Description("分页")]
        [JsonProperty("page")]
        public string Page { get; set; } = "1,20";
        /// <summary>
        /// 日期
        /// </summary>
        [Description("日期")]
        [JsonProperty("date")]
        public string Date { get; set; } = "";
        /// <summary>
        /// 排序
        /// </summary>
        [Description("排序")]
        [JsonProperty("sort")]
        public string Sort { get; set; } = "";
        /// <summary>
        /// 状态
        /// </summary>
        [Description("状态")]
        [JsonProperty("status")]
        public int[] Status { get; set; } = new int[] { };
    }
    /// <summary>
    /// 
    /// </summary>
    public class DTO_Id
    {
        /// <summary>
        /// id
        /// </summary>
        [Description("id")]
        [JsonProperty("id")]
        public int Id { get; set; } = -1;
    }
    /// <summary>
    /// 
    /// </summary>
    public class DTO_Pid
    {
        /// <summary>
        /// 上级Id
        /// </summary>
        [Description("上级Id")]
        [JsonProperty("pid")]
        public int Pid { get; set; } = -1;
    }
    /// <summary>
    /// 
    /// </summary>
    public class DTO_EmployeeId
    {
        /// <summary>
        /// 员工Id
        /// </summary>
        [Description("员工Id")]
        [JsonProperty("employeeId")]
        public int EmployeeId { get; set; } = -1;
    }
    /// <summary>
    /// 
    /// </summary>
    public class DTO_OrgId
    {
        /// <summary>
        /// 部门Id
        /// </summary>
        [Description("部门Id")]
        [JsonProperty("orgId")]
        public int OrgId { get; set; } = -1;
    }
    /// <summary>
    /// 
    /// </summary>
    public class DTO_KeyWord
    {
        /// <summary>
        /// 关键字
        /// </summary>
        [Description("关键字")]
        [JsonProperty("keyWord")]
        public string KeyWord { get; set; } = "";
    }
    /// <summary>
    /// 
    /// </summary>
    public class DTO_DateRange
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        [Description("开始时间")]
        [JsonProperty("minDate")]
        public DateTime MinDate { get; set; } = DateTime.MinValue;
        /// <summary>
        /// 结束时间
        /// </summary>
        [Description("结束时间")]
        [JsonProperty("maxDate")]
        public DateTime MaxDate { get; set; } = DateTime.Now;
    }
    /// <summary>
    /// 
    /// </summary>
    public class DTO_WeChatOpenId
    {
        /// <summary>
        /// 微信OpenId
        /// </summary>
        [Description("微信OpenId")]
        [JsonProperty("weChatOpenId")]
        public string WeChatOpenId { get; set; } = "";
    }
    /// <summary>
    /// 带配置信息的关键字查询条件，用于树结构
    /// </summary>
    public class DTO_KeyWordWithConfig<T>
    {
        /// <summary>
        /// 关键字
        /// </summary>
        [Description("关键字")]
        [JsonProperty("keyWord")]
        public string KeyWord { get; set; } = "";
        /// <summary>
        /// 配置
        /// </summary>
        [Description("配置")]
        [JsonProperty(PropertyName = "config")]
        public Config<T> Config { get; set; } = new Config<T>("StatusKey", "Name", "Id", "Pid", "true");
    }
    /// <summary>
    /// 带配置信息的Id查询条件，用于树结构
    /// </summary>
    public class DTO_IdWithConfig<T>
    {
        /// <summary>
        /// Id
        /// </summary>
        [Description("Id")]
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// 配置
        /// </summary>
        [Description("配置")]
        [JsonProperty(PropertyName = "config")]
        public Config<T> Config { get; set; } = new Config<T>("StatusKey", "Name", "Id", "Pid", "true");
    }
    /// <summary>
    /// 带配置信息的上级Id查询条件，用于树结构
    /// </summary>
    public class DTO_PidWithConfig<T>
    {
        /// <summary>
        /// 上级Id
        /// </summary>
        [Description("上级Id")]
        [JsonProperty("pid")]
        public int Pid { get; set; } = -1;
        /// <summary>
        /// 配置
        /// </summary>
        [Description("配置")]
        [JsonProperty(PropertyName = "config")]
        public Config<T> Config { get; set; } = new Config<T>("StatusKey", "Name", "Id", "Pid", "true");
    }
    /// <summary>
    /// 带配置信息的员工Id查询条件，用于树结构
    /// </summary>
    public class DTO_EmployeeIdWithConfig<T>
    {
        /// <summary>
        /// 员工Id
        /// </summary>
        [Description("员工Id")]
        [JsonProperty("员工Id")]
        public int EmployeeId { get; set; } = -1;
        /// <summary>
        /// 配置
        /// </summary>
        [Description("配置")]
        [JsonProperty(PropertyName = "config")]
        public Config<T> Config { get; set; } = new Config<T>("StatusKey", "Name", "Id", "Pid", "true");
    }
}
