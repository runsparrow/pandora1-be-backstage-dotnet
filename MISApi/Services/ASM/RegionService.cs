using MISApi.CacheServices.WFM;
using MISApi.Entities.ASM;
using MISApi.Entities.WFM;
using System;

namespace MISApi.Services.ASM
{
    /// <summary>
    /// 
    /// </summary>
    public class RegionService
    {

        #region CreateService
        /// <summary>
        /// CreateService
        /// </summary>
        public class CreateService : Base.RegionService.CreateService
        {
            /// <summary>
            /// 定义事务服务
            /// </summary>
            private TransService transService;
            /// <summary>
            /// 构造函数
            /// </summary>
            public CreateService()
            {
                transService = new TransService();
            }
        }

        #endregion

        #region UpdateService
        /// <summary>
        /// UpdateService
        /// </summary>
        public class UpdateService : Base.RegionService.UpdateService
        {
            /// <summary>
            /// 定义事务服务
            /// </summary>
            private TransService transService;
            /// <summary>
            /// 构造函数
            /// </summary>
            public UpdateService()
            {
                transService = new TransService();
            }
        }
        #endregion

        #region DeleteService
        /// <summary>
        /// DeleteService
        /// </summary>
        public class DeleteService : Base.RegionService.DeleteService
        {

        }
        #endregion

        #region ColumnsService
        /// <summary>
        /// ColumnsMode Service
        /// </summary>
        public class ColumnsService : Base.RegionService.ColumnsService
        {

        }

        #endregion

        #region RowService

        /// <summary>
        /// 
        /// </summary>
        public class RowService : Base.RegionService.RowService
        {

        }

        #endregion

        #region RowsService

        /// <summary>
        /// 
        /// </summary>
        public class RowsService : Base.RegionService.RowsService
        {

        }

        #endregion
    }
}