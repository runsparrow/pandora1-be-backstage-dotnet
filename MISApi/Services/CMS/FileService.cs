using MISApi.Entities.CMS;
using System;

namespace MISApi.Services.CMS
{
    /// <summary>
    /// 
    /// </summary>
    public class FileService
    {
        /// <summary>
        /// 定义事务服务
        /// </summary>
        private TransService transService;
        /// <summary>
        /// 构造函数
        /// </summary>
        public FileService()
        {
            transService = new TransService();
        }
        /// <summary>
        /// 上传商品
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual File Upload(File entity)
        {
            try
            {
                // 定义
                File result = new File();
                // 事务
                transService.TransRegist(delegate {
                    // 新增商品
                    result.Goods = new GoodsService.CreateService().ToOpen(entity.Goods);
                    // 新增上传记录
                    result.Upload = new UploadService.CreateService().Execute(new Upload
                    {
                        GoodsId = result.Goods.Id,
                        GoodsName = result.Goods.Name,
                        MemberId = entity.Member.Id,
                        MemberName = entity.Member.Name,
                        UploadResult = true
                    });
                    // 用户剩余上传数
                    entity.Member = new MemberService.RowService().ById(entity.Member.Id);
                    if(entity.Member != null)
                    {
                        entity.Member.ReUploadCount = entity.Member.ReUploadCount > 0 ? entity.Member.ReUploadCount - 1 : 0;
                        new MemberService.UpdateService().Execute(entity.Member);
                    }
                });
                // 提交
                transService.TransCommit();
                // 返回
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.FileService.Upload", ex);
            }
        }
        /// <summary>
        /// 下载商品
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual File Down(File entity)
        {
            try
            {
                // 定义
                File result = new File();
                // 事务
                transService.TransRegist(delegate {
                    // 新增下载记录
                    result.Down = new DownService.CreateService().Execute(new Down
                    {
                        GoodsId = entity.Goods.Id,
                        GoodsName = entity.Goods.Name,
                        MemberId = entity.Member.Id,
                        MemberName = entity.Member.Name,
                        DownResult = true
                    });
                    // 修改商品下载次数
                    entity.Goods = new GoodsService.RowService().ById(entity.Goods.Id);
                    if(entity.Goods != null)
                    {
                        entity.Goods.DownCount++;
                        result.Goods = new GoodsService.UpdateService().Execute(entity.Goods);
                    }
                    // 用户剩余下载数
                    entity.Member = new MemberService.RowService().ById(entity.Member.Id);
                    if (entity.Member != null)
                    {
                        entity.Member.ReDownCount = entity.Member.ReDownCount > 0 ? entity.Member.ReDownCount - 1 : 0;
                        new MemberService.UpdateService().Execute(entity.Member);
                    }
                });
                // 提交
                transService.TransCommit();
                // 返回
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.FileService.Down", ex);
            }
        }
    }
}
