﻿using MISApi.Entities.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISApi.Services.CMS
{
    /// <summary>
    /// 
    /// </summary>
    public class MemberActionService
    {
        /// <summary>
        /// 定义事务服务
        /// </summary>
        private TransService transService;
        /// <summary>
        /// 构造函数
        /// </summary>
        public MemberActionService()
        {
            transService = new TransService();
        }
        /// <summary>
        /// 收藏
        /// </summary>
        /// <param name="goodsId">商品Id</param>
        /// <param name="memberId">会员Id</param>
        /// <returns></returns>
        public virtual void Collect(int goodsId, int memberId)
        {
            try
            {
                // 事务
                transService.TransRegist(delegate {
                    // 获取商品
                    var goods = new GoodsService.RowService().ById(goodsId);
                    // 获取会员
                    var member = new GoodsService.RowService().ById(memberId);
                    // 新增收藏记录
                    new CollectService.CreateService().Create(new Collect
                    {
                        GoodsId = goods.Id,
                        GoodsName = goods.Name,
                        GoodsUrl = goods.Url,
                        MemberId = member.Id,
                        MemberName = member.Name,
                        CollectDateTime = DateTime.Now
                    });
                    // 商品被收藏数量
                    goods.CollectCount++;
                    new GoodsService.UpdateService().Update(goods);
                });
                // 提交
                transService.TransCommit();
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.MemberActionService.Collect", ex);
            }
        }
        /// <summary>
        /// 取消收藏
        /// </summary>
        /// <param name="goodsId">商品Id</param>
        /// <param name="memberId">会员Id</param>
        /// <returns></returns>
        public virtual void Uncollect(int goodsId, int memberId)
        {
            try
            {
                // 事务
                transService.TransRegist(delegate {
                    // 获取商品
                    var goods = new GoodsService.RowService().ById(goodsId);
                    // 获取会员
                    var member = new GoodsService.RowService().ById(memberId);
                    // 新增收藏记录
                    new CollectService.CreateService().Create(new Collect
                    {
                        GoodsId = goods.Id,
                        GoodsName = goods.Name,
                        GoodsUrl = goods.Url,
                        MemberId = member.Id,
                        MemberName = member.Name,
                        CollectDateTime = DateTime.Now
                    });
                    // 商品被收藏数量
                    goods.CollectCount--;
                    new GoodsService.UpdateService().Update(goods);
                });
                // 提交
                transService.TransCommit();
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.MemberActionService.Uncollect", ex);
            }
        }
        /// <summary>
        /// 买套餐
        /// </summary>
        /// <param name="serialEntity"></param>
        /// <param name="memberPowerId"></param>
        /// <returns></returns>
        public virtual void PayMemberPower(Serial serialEntity, int memberPowerId)
        {
            try
            {
                // 事务
                transService.TransRegist(delegate {
                    // 新增流水
                    var serial = new SerialService.CreateService().ToStatus(serialEntity, "cms.serial.open");
                    // 修改会员相关信息
                    var member = new MemberService.UpdateService().AddByMemberPowerId(serialEntity.PayerId, memberPowerId);
                    // 新增充值记录
                    new RechargeService.CreateService().Execute(new Recharge
                    {
                        MemberId = member.Id,
                        MemberName = member.Name,
                        SerialNo = serial.SerialNo,
                        DealAmount = serial.DealAmount,
                        DealDateTime = serial.DealDateTime
                    });
                });
                // 提交
                transService.TransCommit();
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.MemberActionService.PayMemberPower", ex);
            }
        }
        /// <summary>
        /// 退套餐
        /// </summary>
        /// <param name="serialEntity"></param>
        /// <param name="memberPowerId"></param>
        /// <returns></returns>
        public virtual void RefundMemberPower(Serial serialEntity, int memberPowerId)
        {
            try
            {
                // 事务
                transService.TransRegist(delegate {
                    // 新增流水
                    var serial = new SerialService.CreateService().ToStatus(serialEntity, "cms.serial.open");
                    // 修改会员
                    var member = new MemberService.UpdateService().ReduceByMemberPowerId(serialEntity.ReceiverId, memberPowerId);
                    // 新增充值记录
                    new RechargeService.CreateService().Execute(new Recharge
                    {
                        MemberId = member.Id,
                        MemberName = member.Name,
                        SerialNo = serial.SerialNo,
                        DealAmount = -1 * serial.DealAmount,
                        DealDateTime = serial.DealDateTime
                    });
                });
                // 提交
                transService.TransCommit();
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.MemberActionService.PayMemberPower", ex);
            }
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
                    result.Goods = new GoodsService.CreateService().ToStatus(entity.Goods, "cms.goods.open");
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
                    if (entity.Member != null)
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
                throw new Exception("MISApi.Services.CMS.MemberActionService.Upload", ex);
            }
        }
        /// <summary>
        /// 上传商品（多条）
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual List<File> Upload(List<File> entities)
        {
            try
            {
                // 定义
                List<File> results = new List<File>();
                // 事务
                transService.TransRegist(delegate {
                    entities.ForEach(entity =>
                    {
                        results.Add(
                            new MemberActionService().Upload(entity)
                        );
                    });
                });
                // 提交
                transService.TransCommit();
                // 返回
                return results;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.MemberActionService.Upload", ex);
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
                    if (entity.Goods != null)
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
                throw new Exception("MISApi.Services.CMS.MemberActionService.Down", ex);
            }
        }
        /// <summary>
        /// 下载商品（多条）
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual List<File> Down(List<File> entities)
        {
            try
            {
                // 定义
                List<File> results = new List<File>();
                // 事务
                transService.TransRegist(delegate {
                    entities.ForEach(entity =>
                    {
                        results.Add(
                            new MemberActionService().Down(entity)
                        );
                    });
                });
                // 提交
                transService.TransCommit();
                // 返回
                return results;
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Services.CMS.MemberActionService.Down", ex);
            }
        }
    }
}
