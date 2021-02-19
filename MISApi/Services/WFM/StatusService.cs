namespace MISApi.Services.WFM
{
    /// <summary>
    /// 
    /// </summary>
    public class StatusService
    {

        #region CreateService
        /// <summary>
        /// CreateService
        /// </summary>
        public class CreateService : Base.StatusService.CreateService
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
        public class UpdateService : Base.StatusService.UpdateService
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
        public class DeleteService : Base.StatusService.DeleteService
        {

        }
        #endregion

        #region ColumnsService
        /// <summary>
        /// ColumnsMode Service
        /// </summary>
        public class ColumnsService : Base.StatusService.ColumnsService
        {

        }

        #endregion

        #region RowService

        /// <summary>
        /// 
        /// </summary>
        public class RowService : Base.StatusService.RowService
        {

        }

        #endregion

        #region RowsService

        /// <summary>
        /// 
        /// </summary>
        public class RowsService : Base.StatusService.RowsService
        {

        }

        #endregion
    }
}