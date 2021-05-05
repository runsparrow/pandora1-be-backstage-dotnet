namespace MISApi.Services.CMS
{
    /// <summary>
    /// 
    /// </summary>
    public class CollectService
    {

        #region CreateService
        /// <summary>
        /// CreateService
        /// </summary>
        public class CreateService : Base.CollectService.CreateService
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
        public class UpdateService : Base.CollectService.UpdateService
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
        public class DeleteService : Base.CollectService.DeleteService
        {

        }
        #endregion

        #region ColumnsService
        /// <summary>
        /// ColumnsMode Service
        /// </summary>
        public class ColumnsService : Base.CollectService.ColumnsService
        {

        }

        #endregion

        #region RowService

        /// <summary>
        /// 
        /// </summary>
        public class RowService : Base.CollectService.RowService
        {

        }

        #endregion

        #region RowsService

        /// <summary>
        /// 
        /// </summary>
        public class RowsService : Base.CollectService.RowsService
        {

        }

        #endregion
    }
}