using MISApi.Entities.CMS;
using System;

namespace MISApi.Services.CMS
{
    /// <summary>
    /// 
    /// </summary>
    public class RMSService
    {
        /// <summary>
        /// 定义事务服务
        /// </summary>
        private TransService transService;
        /// <summary>
        /// 构造函数
        /// </summary>
        public RMSService()
        {
            transService = new TransService();
        }
        /// <summary>
        /// 上传商品
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual RMS Upload(RMS entity)
        {
            try
            {
                // 定义
                RMS result = new RMS();
                // 事务
                transService.TransRegist(delegate {
                    // 新增商品
                    result.Goods = new GoodsService.CreateService().ToOpen(entity.Goods);
                    // 新增上传记录
                    entity.Upload.GoodsId = result.Goods.Id;
                    entity.Upload.GoodsName = result.Goods.Name;
                    entity.Upload.MemberId = result.Member.Id;
                    entity.Upload.MemberName = result.Member.Name;
                    entity.Upload.UploadResult = true;
                    result.Upload = new UploadService.CreateService().Execute(entity.Upload);
                    // 用户剩余上传数
                    entity.Member = new MemberService.RowService().ById(entity.Member.Id);
                    entity.Member.ReUploadCount--;
                    new MemberService.UpdateService().Execute(entity.Member);
                });
                // 提交
                transService.TransCommit();
                // 返回
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.RMSService.Upload", ex);
            }
        }
        /// <summary>
        /// 下载商品
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual RMS Down(RMS entity)
        {
            try
            {
                // 定义
                RMS result = new RMS();
                // 事务
                transService.TransRegist(delegate {
                    // 新增商品
                    result.Goods = new GoodsService.CreateService().ToOpen(entity.Goods);
                    // 新增下载记录
                    entity.Down.GoodsId = result.Goods.Id;
                    entity.Down.GoodsName = result.Goods.Name;
                    entity.Down.MemberId = result.Member.Id;
                    entity.Down.MemberName = result.Member.Name;
                    entity.Down.DownResult = true;
                    result.Down = new DownService.CreateService().Execute(entity.Down);
                    // 用户剩余上传数
                    entity.Member = new MemberService.RowService().ById(entity.Member.Id);
                    entity.Member.ReUploadCount--;
                    new MemberService.UpdateService().Execute(entity.Member);
                });
                // 提交
                transService.TransCommit();
                // 返回
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.RMSService.Down", ex);
            }
        }
    }
}
