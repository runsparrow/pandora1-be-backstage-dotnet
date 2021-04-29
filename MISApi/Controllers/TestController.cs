using Microsoft.AspNetCore.Mvc;
using System;

namespace MISApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class TestController: Controller
    {
        /// <summary>
        /// 测试MISApi连接
        /// </summary>
        /// <returns></returns>
        [Route("MIS/Test1", Name = "MIS_Test")]
        [HttpGet]
        public IActionResult Test()
        {
            try
            {
                //RedisCacheHelper.SetStringValue("testvalue", "redis");
                //return new OkObjectResult(new TestObject() { Title = "测试通过", Content = RedisCacheHelper.GetStringValue("testvalue") });
                //RedisCacheHelper.Set("objectValue", new Entities.AVM.User { Name = "Test" });
                //return new OkObjectResult(new TestObject() { Title = "测试通过", Content = ((Entities.AVM.User)RedisCacheHelper.Get("objectValue")).Name});

                return new OkObjectResult(new TestObject() { Title = "测试通过", Content = "MIS Test Success！" });
            }
            catch (Exception ex)
            {
                throw new Exception("TestController.Test", ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public class TestObject
        {
            /// <summary>
            /// 
            /// </summary>
            public string Title { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string Content { get; set; }
        }
    }
}
