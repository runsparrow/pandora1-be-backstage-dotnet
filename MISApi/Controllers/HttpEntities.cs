using MISApi.Entities.CMS;
using MISApi.HttpClients.HttpModes.TreeMode.BootstrapTreeView;
using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace MISApi.Controllers.HttpEntities
{
    /// <summary>
    /// 
    /// </summary>
    public class DTO_Login
    {
        /// <summary>
        /// 账户名
        /// </summary>
        [Description("账户名")]
        [JsonProperty("name")]
        [DefaultValue("")]
        public string Name { get; set; } = "";
        /// <summary>
        /// 账户密码
        /// </summary>
        [Description("账户密码")]
        [JsonProperty("password")]
        [DefaultValue("")]
        public string Password { get; set; } = "";
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
        [DefaultValue("")]
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
        [DefaultValue(false)]
        public bool Result { get; set; } = false;
        /// <summary>
        /// 信息
        /// </summary>
        [Description("信息")]
        [JsonProperty("message")]
        [DefaultValue("")]
        public string Message { get; set; } = "";
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
        [DefaultValue(-1)]
        public int UserId { get; set; } = -1;
        /// <summary>
        /// 用户名
        /// </summary>
        [Description("用户名")]
        [JsonProperty("userName")]
        [DefaultValue("")]
        public string UserName { get; set; } = "";
        /// <summary>
        /// 实名
        /// </summary>
        [Description("实名")]
        [JsonProperty("realName")]
        [DefaultValue("")]
        public string RealName { get; set; } = "";
    }
    /// <summary>
    /// 
    /// </summary>
    public class DTO_Page
    {
        /// <summary>
        /// <p>关键字</p>
        /// <p>规则: 模糊查询值^指定查询字段=指定查询值^指定查询字段=指定查询值^......以此类推</p>
        /// <p>第一部模糊查询值一般用于最大的字符串模糊查询</p>
        /// <p>第二部分根据^拆分，拆分后字段代表特定的查询条件，值代表查询值，可在方法KeyWordExtQueryable中找到对应的处理代码</p>
        /// </summary>
        [Description("关键字")]
        [JsonProperty("keyWord")]
        [DefaultValue("")]
        public string KeyWord { get; set; } = "";
        /// <summary>
        /// <p>分页</p>
        /// <p>规则: 当前页码^每页记录数</p>
        /// </summary>
        [Description("分页")]
        [JsonProperty("page")]
        [DefaultValue("1^20")]
        public string Page { get; set; } = "1^20";
        /// <summary>
        /// <p>日期</p>
        /// <p>规则：时间字段^起始时间^结束时间;时间字段^起始时间^结束时间;......以此类推</p>
        /// <p>参考：CreateDateTime^2020-8-1^2020-8-2;EditDateTime^2020-8-1^2020-8-2;</p>
        /// </summary>
        [Description("日期")]
        [JsonProperty("date")]
        [DefaultValue("")]
        public string Date { get; set; } = "";
        /// <summary>
        /// <p>排序</p>
        /// <p>规则：排序字段^排序方式;排序字段^排序方式;......以此类推</p>
        /// <p>参考：id^asc;name^desc</p>
        /// </summary>
        [Description("排序")]
        [JsonProperty("sort")]
        [DefaultValue("")]
        public string Sort { get; set; } = "";
        /// <summary>
        /// <p>状态</p>
        /// <p>规则：[状态值,状态值,状态值,......以此类推]</p>
        /// <p>参考：[1,2,3,4,5]</p>
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
        [DefaultValue(-1)]
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
        [DefaultValue(-1)]
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
        [DefaultValue(-1)]
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
        [DefaultValue(-1)]
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
        [DefaultValue("")]
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
        [DefaultValue(typeof(DateTime), "0001-01-01")]
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
        [DefaultValue("")]
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
        [DefaultValue("")]
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
        [DefaultValue(-1)]
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
        [DefaultValue(-1)]
        public int EmployeeId { get; set; } = -1;
        /// <summary>
        /// 配置
        /// </summary>
        [Description("配置")]
        [JsonProperty(PropertyName = "config")]
        public Config<T> Config { get; set; } = new Config<T>("StatusKey", "Name", "Id", "Pid", "true");
    }
}
