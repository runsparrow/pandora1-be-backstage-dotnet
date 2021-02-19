using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MISApi.Controllers
{
    /// <summary>
    /// Api Controller 基础类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [ApiController]
    [Route("", Name = "")]
    public abstract class BaseController<T> : ControllerBase
        where T : class
    {
        private object service = Type.GetType($"{typeof(T).FullName.Split(".")[0]}.Services.{typeof(T).FullName.Split(".")[2]}.{typeof(T).Name}Service") .GetConstructor(Type.EmptyTypes).Invoke(null);

        #region Protected 方法
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected bool Exists(int id)
        {
            return DbSetEntity().Count(e => (int)EntityPropertyValue(e, "Id") == id) > 0;
        }

        /// <summary>
        /// 从 TService 中获取 T 数据集合
        /// </summary>
        /// <returns>TService.T</returns>
        protected DbSet<T> DbSetEntity()
        {
            PropertyInfo p = service.GetType().GetProperty(typeof(T).Name);
            if (p == null)
            {
                throw new Exception("Not found this property");
            }
            return (DbSet<T>)p.GetValue(service);
        }

        /// <summary>
        /// 从 Model 中获取 属性值
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyName"></param>
        /// <returns>T.Property.Value</returns>
        protected object EntityPropertyValue(T entity, string propertyName)
        {
            PropertyInfo p = entity.GetType().GetProperty(propertyName);
            if (p == null)
            {
                throw new Exception("Not found this property");
            }
            return p.GetValue(entity);
        }

        /// <summary>
        /// 使用反射方法调用Service类中对应的方法。
        /// </summary>
        /// <param name="name">方法名</param>
        /// <param name="objs">参数</param>
        /// <returns></returns>
        protected virtual object ServiceInvokeValue(string name, params object[] objs)
        {
            MethodInfo[] mis = service.GetType().GetMethods();
            for (int index = 0; index < mis.Length; index++)
            {
                if (mis[index].Name.Equals(name))
                {
                    //判断参数是否完全匹配
                    ParameterInfo[] paramsInfo = mis[index].GetParameters();
                    //如果参数个数不匹配直接跳出本次循环
                    if (paramsInfo.Length != objs.Length)
                    {
                        continue;
                    }
                    //判断每一个参数类型是否完全匹配
                    bool flag = true;
                    for (int i = 0; i < paramsInfo.Length; i++)
                    {
                        if (paramsInfo[i].ParameterType.FullName != objs[i].GetType().FullName)
                        {
                            flag = false;
                        }
                    }
                    if (!flag)
                        continue;
                    //将 params object [] 参数转换成 invoke需要的 object [] 
                    object[] o = new object[objs.Length];
                    for (int i = 0; i < objs.Length; i++)
                    {
                        o[i] = objs[i];
                    }
                    //返回结果
                    return mis[index].Invoke(service, o);
                }
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        protected virtual object HttpEntityToResponse<TRequest>(TRequest request) where TRequest : class, new()
        {
            TRequest requestClass = new TRequest();
            MethodInfo m = requestClass.GetType().GetMethod("ToResponse");
            return m.Invoke(requestClass, new object[] { request });
        }

        #endregion

        #region RPC 方式

        #region CreateMode
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        protected virtual IActionResult Post(HttpClients.HttpModes.CreateMode.Request<T> request)
        {
            try
            {
                // 定义参数类型
                Type[] types = new Type[request.Function.Args.Length + 1];
                // 定义参数值
                object[] parameters = new object[request.Function.Args.Length + 1];
                // 初始化第一个参数
                if (request.Entity != null)
                {
                    types[0] = typeof(T);
                    parameters[0] = request.Entity;
                }
                else if (request.Entities.Count > 0)
                {
                    types[0] = typeof(List<T>);
                    parameters[0] = request.Entities;
                }
                else
                {
                    throw new Exception("缺少实体数据！");
                }
                // 多参数类型复制
                for (var i = 1; i < request.Function.Args.Length + 1; i++)
                {
                    types[i] = request.Function.Args[i - 1].Type;
                    parameters[i] = request.Function.Args[i - 1].Value;
                }
                // 寻找对应的方法
                object intance  = Type.GetType(service.GetType().FullName + "+CreateService").GetConstructor(Type.EmptyTypes).Invoke(null);
                MethodInfo methodInfo = intance.GetType().GetMethod(request.Function.Name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance, Type.DefaultBinder, types, new ParameterModifier[] {new ParameterModifier(request.Function.Args.Length + 1) });
                if (methodInfo != null)
                {
                    if (request.Entity != null)
                    {
                        return ResponseOk(
                            request.ToResponse(
                                methodInfo.Invoke(intance, parameters) as T
                            )
                        );
                    }
                    else if (request.Entities.Count > 0)
                    {
                        return ResponseOk(
                            request.ToResponse(
                                methodInfo.Invoke(intance, parameters) as List<T>
                            )
                        );
                    }
                }
                throw new Exception("未找到对应方法！");
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.BaseController.Create.Post", ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        protected virtual IActionResult ResponseOk(HttpClients.HttpModes.CreateMode.Response<T> response)
        {
            return Ok(response.Row);
        }
        #endregion

        #region UpdateMode
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        protected virtual IActionResult Post(HttpClients.HttpModes.UpdateMode.Request<T> request)
        {
            try
            {
                // 定义参数类型
                Type[] types = new Type[request.Function.Args.Length + 1];
                // 定义参数值
                object[] parameters = new object[request.Function.Args.Length + 1];
                // 初始化第一个参数
                if (request.Entity != null)
                {
                    types[0] = typeof(T);
                    parameters[0] = request.Entity;
                }
                else if (request.Entities.Count > 0)
                {
                    types[0] = typeof(List<T>);
                    parameters[0] = request.Entities;
                }
                else
                {
                    throw new Exception("缺少实体数据！");
                }
                // 多参数类型复制
                for (var i = 1; i < request.Function.Args.Length + 1; i++)
                {
                    types[i] = request.Function.Args[i - 1].Type;
                    parameters[i] = request.Function.Args[i - 1].Value;
                }
                // 寻找对应的方法
                object intance = Type.GetType(service.GetType().FullName + "+UpdateService").GetConstructor(Type.EmptyTypes).Invoke(null);
                MethodInfo methodInfo = intance.GetType().GetMethod(request.Function.Name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance, Type.DefaultBinder, types, new ParameterModifier[] { new ParameterModifier(request.Function.Args.Length + 1) });
                if (methodInfo != null)
                {
                    if (request.Entity != null)
                    {
                        return ResponseOk(
                            request.ToResponse(
                                methodInfo.Invoke(intance, parameters) as T
                            )
                        );
                    }
                    else if (request.Entities.Count > 0)
                    {
                        return ResponseOk(
                            request.ToResponse(
                                methodInfo.Invoke(intance, parameters) as List<T>
                            )
                        );
                    }
                }
                throw new Exception("未找到对应方法！");
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.BaseController.Update.Post", ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        protected virtual IActionResult ResponseOk(HttpClients.HttpModes.UpdateMode.Response<T> response)
        {
            return Ok(response.Rows);
        }
        #endregion

        #region DeleteMode

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        protected virtual IActionResult Post(HttpClients.HttpModes.DeleteMode.Request<T> request)
        {
            try
            {
                // 定义参数类型
                Type[] types = new Type[request.Function.Args.Length + 1];
                // 定义参数值
                object[] parameters = new object[request.Function.Args.Length + 1];
                // 初始化第一个参数
                if (request.Entity != null)
                {
                    types[0] = typeof(T);
                    parameters[0] = request.Entity;
                }
                else if (request.Entities.Count > 0)
                {
                    types[0] = typeof(List<T>);
                    parameters[0] = request.Entities;
                }
                else
                {
                    throw new Exception("缺少实体数据！");
                }
                // 多参数类型复制
                for (var i = 1; i < request.Function.Args.Length + 1; i++)
                {
                    types[i] = request.Function.Args[i - 1].Type;
                    parameters[i] = request.Function.Args[i - 1].Value;
                }
                // 寻找对应的方法
                object intance = Type.GetType(service.GetType().FullName + "+DeleteService").GetConstructor(Type.EmptyTypes).Invoke(null);
                MethodInfo methodInfo = intance.GetType().GetMethod(request.Function.Name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance, Type.DefaultBinder, types, new ParameterModifier[] { new ParameterModifier(request.Function.Args.Length + 1) });
                if (methodInfo != null)
                {
                    if (request.Entity != null)
                    {
                        return ResponseOk(
                            request.ToResponse(
                                methodInfo.Invoke(intance, parameters) as T
                            )
                        );
                    }
                    else if (request.Entities.Count > 0)
                    {
                        return ResponseOk(
                            request.ToResponse(
                                methodInfo.Invoke(intance, parameters) as List<T>
                            )
                        );
                    }
                }
                throw new Exception("未找到对应方法！");
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.BaseController.Delete.Post", ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        protected virtual IActionResult ResponseOk(HttpClients.HttpModes.DeleteMode.Response<T> response)
        {
            return Ok(response);
        }

        #endregion

        #region ColumnsMode

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        protected virtual IActionResult Post(HttpClients.HttpModes.ColumnsMode.Request<T> request)
        {
            try
            {
                // 寻找对应的方法
                object intance = Type.GetType(service.GetType().FullName + "+ColumnsService").GetConstructor(Type.EmptyTypes).Invoke(null);
                MethodInfo methodInfo = intance.GetType().GetMethod(request.Function.Name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (methodInfo != null)
                {
                    return ResponseOk(
                        request.ToResponse(
                            methodInfo.Invoke(intance, null) as T
                        )
                    );
                }
                throw new Exception("未找到对应方法！");
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.BaseController.Columns.Post", ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        protected virtual IActionResult ResponseOk(HttpClients.HttpModes.ColumnsMode.Response<T> response)
        {
            return Ok(response.Columns);
        }

        #endregion

        #region RowMode

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        protected virtual IActionResult Post(HttpClients.HttpModes.RowMode.Request<T> request)
        {
            try
            {
                // 定义参数类型
                Type[] types = new Type[request.Function.Args.Length];
                // 定义参数值
                object[] parameters = new object[request.Function.Args.Length];
                // 多参数类型复制
                for (var i = 0; i < request.Function.Args.Length; i++)
                {
                    types[i] = request.Function.Args[i].Type;
                    parameters[i] = request.Function.Args[i].Value;
                }
                // 寻找对应的方法
                object intance = Type.GetType(service.GetType().FullName + "+RowService").GetConstructor(Type.EmptyTypes).Invoke(null);
                MethodInfo methodInfo = intance.GetType().GetMethod(request.Function.Name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance, Type.DefaultBinder, types, new ParameterModifier[] { new ParameterModifier(request.Function.Args.Length) });
                if (methodInfo != null)
                {
                    return ResponseOk(
                        request.ToResponse(
                            methodInfo.Invoke(intance, parameters) as T
                        )
                    );
                }
                throw new Exception("未找到对应方法！");
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.BaseController.Row.Post", ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        protected virtual IActionResult ResponseOk(HttpClients.HttpModes.RowMode.Response<T> response)
        {
            return Ok(response.Row);
        }
        #endregion

        #region RowsMode

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        protected virtual IActionResult Post(HttpClients.HttpModes.RowsMode.Request<T> request)
        {
            try
            {
                // 定义参数类型
                Type[] types = new Type[request.Function.Args.Length];
                // 定义参数值
                object[] parameters = new object[request.Function.Args.Length];
                // 多参数类型复制
                for (var i = 0; i < request.Function.Args.Length; i++)
                {
                    types[i] = request.Function.Args[i].Type;
                    parameters[i] = request.Function.Args[i].Value;
                }
                // 寻找对应的方法
                object intance = Type.GetType(service.GetType().FullName + "+RowsService").GetConstructor(Type.EmptyTypes).Invoke(null);
                MethodInfo methodInfo = intance.GetType().GetMethod(request.Function.Name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance, Type.DefaultBinder, types, new ParameterModifier[] { new ParameterModifier(request.Function.Args.Length) });
                if (methodInfo != null)
                {
                    return ResponseOk(
                        request.ToResponse(
                            methodInfo.Invoke(intance, parameters) as List<T>
                        )
                    );
                }
                throw new Exception("未找到对应方法！");
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.BaseController.Rows.Post", ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        protected virtual IActionResult ResponseOk(HttpClients.HttpModes.RowsMode.Response<T> response)
        {
            return Ok(response.Rows);
        }

        #endregion

        #region SingleMode

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        protected virtual IActionResult Post(HttpClients.HttpModes.SingleMode.Request<T> request)
        {
            try
            {
                // 定义参数类型
                Type[] types = new Type[request.Function.Args.Length];
                // 定义参数值
                object[] parameters = new object[request.Function.Args.Length];
                // 多参数类型复制
                for (var i = 0; i < request.Function.Args.Length; i++)
                {
                    types[i] = request.Function.Args[i].Type;
                    parameters[i] = request.Function.Args[i].Value;
                }
                // 寻找对应的方法
                object intance = Type.GetType(service.GetType().FullName + "+RowService").GetConstructor(Type.EmptyTypes).Invoke(null);
                MethodInfo methodInfo = intance.GetType().GetMethod(request.Function.Name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance, Type.DefaultBinder, types, new ParameterModifier[] { new ParameterModifier(request.Function.Args.Length) });
                if (methodInfo != null)
                {
                    return ResponseOk(
                        request.ToResponse(
                            methodInfo.Invoke(intance, parameters) as T
                        )
                    );
                }
                throw new Exception("未找到对应方法！");
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.BaseController.Single.Post", ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        protected virtual IActionResult ResponseOk(HttpClients.HttpModes.SingleMode.Response<T> response)
        {
            return Ok(response);
        }

        #endregion

        #region QueryMode

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        protected virtual IActionResult Post(HttpClients.HttpModes.QueryMode.Request<T> request)
        {
            try
            {
                // 定义参数类型
                Type[] types = new Type[request.Function.Args.Length];
                // 定义参数值
                object[] parameters = new object[request.Function.Args.Length];
                // 多参数类型复制
                for (var i = 0; i < request.Function.Args.Length; i++)
                {
                    types[i] = request.Function.Args[i].Type;
                    parameters[i] = request.Function.Args[i].Value;
                }
                // 寻找对应的方法
                object intance = Type.GetType(service.GetType().FullName + "+RowsService").GetConstructor(Type.EmptyTypes).Invoke(null);
                MethodInfo methodInfo = intance.GetType().GetMethod(request.Function.Name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance, Type.DefaultBinder, types, new ParameterModifier[] { new ParameterModifier(request.Function.Args.Length) });
                if (methodInfo != null)
                {
                    return ResponseOk(
                        request.ToResponse(
                            methodInfo.Invoke(intance, parameters) as List<T>
                        )
                    );
                }
                throw new Exception("未找到对应方法！");
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.BaseController.Query.Post", ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        protected virtual IActionResult ResponseOk(HttpClients.HttpModes.QueryMode.Response<T> response)
        {
            return Ok(response);
        }

        #endregion

        #region TreeMode

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        protected virtual IActionResult Post(HttpClients.HttpModes.TreeMode.BootstrapTreeViewRequest<T> request)
        {
            try
            {
                // 定义参数类型
                Type[] types = new Type[request.Function.Args.Length];
                // 定义参数值
                object[] parameters = new object[request.Function.Args.Length];
                // 多参数类型复制
                for (var i = 0; i < request.Function.Args.Length; i++)
                {
                    types[i] = request.Function.Args[i].Type;
                    parameters[i] = request.Function.Args[i].Value;
                }
                // 寻找对应的方法
                object intance = Type.GetType(service.GetType().FullName + "+RowsService").GetConstructor(Type.EmptyTypes).Invoke(null);
                MethodInfo methodInfo = intance.GetType().GetMethod(request.Function.Name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance, Type.DefaultBinder, types, new ParameterModifier[] { new ParameterModifier(request.Function.Args.Length) });
                if (methodInfo != null)
                {
                    return ResponseOk(
                        request.ToResponse(
                            methodInfo.Invoke(intance, parameters) as List<T>
                        )
                    );
                }
                else
                {
                    // 寻找对应的方法
                    intance = Type.GetType(service.GetType().FullName + "+RowService").GetConstructor(Type.EmptyTypes).Invoke(null);
                    methodInfo = intance.GetType().GetMethod(request.Function.Name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance, Type.DefaultBinder, types, new ParameterModifier[] { new ParameterModifier(request.Function.Args.Length) });
                    if (methodInfo != null)
                    {
                        List<T> list = new List<T>();
                        list.Add(methodInfo.Invoke(intance, parameters) as T);
                        return ResponseOk(
                            request.ToResponse(list)
                        );
                    }
                }
                throw new Exception("未找到对应方法！");
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Controllers.BaseController.Tree.Post", ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        protected virtual IActionResult ResponseOk(HttpClients.HttpModes.TreeMode.BootstrapTreeViewResponse<T> response)
        {
            return Ok(response);
        }
        #endregion

        #endregion

        #region Common 方式
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        protected virtual IActionResult ResponseOk(Response response)
        {
            return Ok(response);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected virtual Response ToResponse(object obj)
        {
            return new Response()
            {
                Result = obj,
                Success = obj != null
            };
        }
        /// <summary>
        /// 
        /// </summary>
        protected new class Response
        {
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "result")]
            public object Result { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "success")]
            public bool Success { get; set; }
        }

        #endregion

        #region Property
        /// <summary>
        /// 
        /// </summary>
        protected string Token
        {
            get
            {
                var authorization = HttpContext.Request.Headers["Authorization"].ToString();
                if (string.IsNullOrEmpty(authorization))
                {
                    return null;
                }
                return HttpContext.Request.Headers["Authorization"].ToString()?.Substring(7);
            }
        }

        #endregion
    }
}