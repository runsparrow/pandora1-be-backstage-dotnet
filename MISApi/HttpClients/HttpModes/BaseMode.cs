using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MISApi.HttpClients.HttpModes.BaseMode
{
    /// <summary>
    /// 
    /// </summary>
    public static class Extension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static object GetValue(this Arg [] args, string name)
        {
            try
            {
                return new List<Arg>(args).Find(row => row.Name.ToLower().Equals(name))?.Value;
            }
            catch(Exception ex)
            {
                throw new Exception("MISApi.HttpClients.HttpModes.BaseMode.Extension.GetValue", ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static Status GetStatus(this Arg[] args)
        {
            try
            {
                var arg = new List<Arg>(args).Find(row => row.Name.ToLower() == "status") ?? new Arg();
                return new Status()
                {
                    Values = arg.Values.ConvertAll(row => int.Parse(row.ToString())).ToArray()
                };
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.HttpClients.HttpModes.BaseMode.Extension.GetStatus", ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static KeyWord GetKeyWord(this Arg [] args)
        {
            try
            {
                return new KeyWord(GetValue(args, "keyword").ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.HttpClients.HttpModes.BaseMode.Extension.GetKeyWord", ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static Date [] GetDates(this Arg[] args)
        {
            try
            {
                return new List<Arg>(args).FindAll(row => row.Type == Type.GetType("System.DateTime") || row.Name.ToLower().Contains("date")).ConvertAll(row => new Date()
                {
                    Name = row.Name,
                    MinDate = row.MinValue == null ? DateTime.MinValue : DateTime.Parse(row.MinValue),
                    MaxDate = row.MaxValue == null ? DateTime.MaxValue : DateTime.Parse(row.MaxValue).TimeOfDay.TotalSeconds == 0 ? DateTime.Parse(row.MaxValue).Date.AddDays(1).AddSeconds(-1) : DateTime.Parse(row.MaxValue)
                }).ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.HttpClients.HttpModes.BaseMode.Extension.GetDates", ex);
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class KeyWord
    {
        #region Construct
        /// <summary>
        /// 
        /// </summary>
        public KeyWord()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="ext"></param>
        public KeyWord(string value, string ext = "")
        {
            Value = value;
            Ext = ext;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="protocal"></param>
        public KeyWord(string protocal)
        {
            protocal = protocal ?? "";
            Value = protocal.IndexOf("^") == -1 ? protocal : protocal.Substring(0, protocal.IndexOf("^"));
            Ext = protocal.Substring(protocal.IndexOf("^") + 1, protocal.Length - protocal.IndexOf("^") - 1);
        }
        #endregion

        #region Property
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public virtual string Value { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "ext")]
        public virtual string Ext { get; set; } = "";
        #endregion
    }
    /// <summary>
    /// 
    /// </summary>
    public class Page
    {
        #region Construct
        /// <summary>
        /// 
        /// </summary>
        public Page()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="size"></param>
        public Page(int index, int size)
        {
            Index = index;
            Size = size;
        }
        /// <summary>
        /// 协议格式：1^20
        /// </summary>
        /// <param name="protocal"></param>
        public Page(string protocal)
        {
            try
            {
                string[] protocalArray = protocal.Split("^");
                Index = int.Parse(protocalArray[0]);
                Size = int.Parse(protocalArray[1]);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.HttpClients.HttpModes.BaseMode.Page:" + ex.Message);
            }
        }
        #endregion

        #region Property
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "index")]
        public virtual int Index { get; set; } = 1;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "size")]
        public virtual int Size { get; set; } = int.MaxValue;
        #endregion
    }
    /// <summary>
    /// 
    /// </summary>
    public class Date
    {
        #region Construct
        /// <summary>
        /// 
        /// </summary>
        public Date()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="minDate"></param>
        /// <param name="maxDate"></param>
        public Date(string name, DateTime minDate, DateTime maxDate)
        {
            Name = name;
            MinDate = minDate;
            MaxDate = maxDate;
        }
        /// <summary>
        /// 协议格式：CreateDateTime^2020-8-1^2020-8-2
        /// </summary>
        /// <param name="protocal"></param>
        public Date(string protocal)
        {
            try
            {
                string[] protocalArray = protocal.Split("^");
                Name = protocalArray[0];
                MinDate = DateTime.Parse(protocalArray[1]);
                MaxDate = DateTime.Parse(protocalArray[2]);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.HttpClients.HttpModes.BaseMode.Date:" + ex.Message);
            }
        }
        #endregion

        #region Property
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public virtual string Name { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "minDate")]
        public virtual DateTime MinDate { get; set; } = DateTime.MinValue;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "maxDate")]
        public virtual DateTime MaxDate { get; set; } = DateTime.MaxValue;
        #endregion

        #region Methods
        /// <summary>
        /// 协议格式：CreateDateTime^2020-8-1^2020-8-2;EditDateTime^2020-8-1^2020-8-2
        /// </summary>
        /// <param name="protocal"></param>
        /// <returns></returns>
        public Date[] Init(string protocal)
        {
            try
            {
                if (string.IsNullOrEmpty(protocal))
                {
                    return null;
                }
                string[] protocalArray = protocal.Split(";");
                Date[] dateArray = new Date[protocalArray.Length];
                for (var i = 0; i < protocalArray.Length; i++)
                {
                    dateArray[i] = new Date(protocalArray[i]);
                }
                return dateArray;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.HttpClients.HttpModes.BaseMode.Date.Init:" + ex.Message);
            }
        }
        #endregion
    }
    /// <summary>
    /// 
    /// </summary>
    public class Status
    {
        #region Construct
        /// <summary>
        /// 
        /// </summary>
        public Status()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        public Status(params int[] values)
        {
            Values = values;
        }
        /// <summary>
        /// 协议格式：1^2^3^4^5
        /// </summary>
        /// <param name="protocal"></param>
        public Status(string protocal)
        {
            try
            {
                string[] protocalArray = protocal.Split("^");
                for (var i = 0; i < protocalArray.Length; i++)
                {
                    Values[i] = int.Parse(protocalArray[i]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.HttpClients.HttpModes.BaseMode.Status:" + ex.Message);
            }
        }
        #endregion

        #region Property
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "values")]
        public virtual int[] Values { get; set; } = new int[] { };
        #endregion
    }
    /// <summary>
    /// 
    /// </summary>
    public class Sort
    {
        #region Construct
        /// <summary>
        /// 
        /// </summary>
        public Sort()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="mode"></param>
        public Sort(string name, SortMode mode = SortMode.ASC)
        {
            Name = name;
            Mode = mode;
        }
        /// <summary>
        /// 协议格式：id^asc
        /// </summary>
        /// <param name="protocal"></param>
        public Sort(string protocal)
        {
            try
            {
                string[] protocalArray = protocal.Split("^");
                Name = protocalArray[0];
                Mode = protocalArray[1].ToLower() == SortMode.ASC.ToString().ToLower() ? SortMode.ASC : SortMode.DESC;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.HttpClients.HttpModes.BaseMode.Sort:" + ex.Message);
            }
        }
        #endregion

        #region Property
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public virtual string Name { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "mode")]
        public virtual SortMode Mode { get; set; } = SortMode.ASC;
        #endregion

        #region Methods
        /// <summary>
        /// 协议格式：id^asc;name^desc
        /// </summary>
        /// <param name="protocal"></param>
        /// <returns></returns>
        public Sort[] Init(string protocal)
        {
            try
            {
                if (string.IsNullOrEmpty(protocal))
                {
                    return null;
                }
                string[] protocalArray = protocal.Split(";");
                Sort[] sortArray = new Sort[protocalArray.Length];
                for (var i = 0; i < protocalArray.Length; i++)
                {
                    sortArray[i] = new Sort(protocalArray[i]);
                }
                return sortArray;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.HttpClients.HttpModes.BaseMode.Sort.Init:" + ex.Message);
            }
        }
        #endregion

        #region Enum
        /// <summary>
        /// 
        /// </summary>
        public enum SortMode { 
            /// <summary>
            /// 
            /// </summary>
            ASC, 
            /// <summary>
            /// 
            /// </summary>
            DESC 
        }
        #endregion
    }
    /// <summary>
    /// 
    /// </summary>
    public class Join
    {
        #region Construct
        /// <summary>
        /// 
        /// </summary>
        public Join()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="mode"></param>
        public Join(string name, JoinMode mode = JoinMode.LEFT)
        {
            Name = name;
            Mode = mode;
        }
        #endregion

        #region Property
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public virtual string Name { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "mode")]
        public virtual JoinMode Mode { get; set; } = JoinMode.LEFT;

        #endregion

        #region Enum
        /// <summary>
        /// 
        /// </summary>
        public enum JoinMode { 
            /// <summary>
            /// 
            /// </summary>
            LEFT, 
            /// <summary>
            /// 
            /// </summary>
            RIGHT, 
            /// <summary>
            /// 
            /// </summary>
            INNER 
        }
        #endregion

        #region Methods
        /// <summary>
        /// 协议格式：id^asc;name^desc
        /// </summary>
        /// <param name="protocal"></param>
        /// <returns></returns>
        public Join[] Init(string protocal)
        {
            try
            {
                string[] protocalArray = protocal.Split(";");
                Join[] joinArray = new Join[protocalArray.Length];
                for (var i = 0; i < protocalArray.Length; i++)
                {
                    joinArray[i] = new Join(protocalArray[i]);
                }
                return joinArray;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.HttpClients.HttpModes.BaseMode.Join.Init:" + ex.Message);
            }
        }
        #endregion
    }
    /// <summary>
    /// 
    /// </summary>
    public class Arg
    {
        #region Construct
        /// <summary>
        /// 
        /// </summary>
        public Arg()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Arg(object value)
        {
            Name = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().GetParameters()[0].Name;
            Value = value;
            Type = value.GetType();
        }
        #endregion

        #region Method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Arg SetValue(object value)
        {
            return new Arg
            {
                Name = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().GetParameters()[0].Name,
                Value = value,
                Type = value.GetType(),
            };
        }
        #endregion

        #region Property
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public virtual string Name { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public virtual object Value { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "values")]
        public virtual List<object> Values { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "operation")]
        public virtual string Operation { get; set; } = "equals";
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "logic")]
        public virtual string Logic { get; set; } = "and";
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public virtual Type Type { get; set; } = Type.GetType("System.String");
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "minValue")]
        public virtual string MinValue { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "maxValue")]
        public virtual string MaxValue { get; set; } = "";

        #endregion
    }
    /// <summary>
    /// 
    /// </summary>
    public class Function
    {
        #region Construct
        /// <summary>
        /// 
        /// </summary>
        public Function()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="args"></param>
        public Function(string name, params Arg[] args)
        {
            Name = name;
            Args = args;
        }
        #endregion

        #region Property
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public virtual string Name { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "args")]
        public virtual Arg[] Args { get; set; } = new Arg[] { };
        #endregion

    }

}