using MISApi.Entities.CMS;
using System;
using System.Collections.Generic;

namespace MISApi.Services.CMS
{
    /// <summary>
    /// 
    /// </summary>
    public class PaymentService
    {
        /// <summary>
        /// 定义事务服务
        /// </summary>
        private TransService transService;
        /// <summary>
        /// 构造函数
        /// </summary>
        public PaymentService()
        {
            transService = new TransService();
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
                throw new Exception("MISApi.Services.CMS.PaymentService.PayMemberPower", ex);
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
                throw new Exception("MISApi.Services.CMS.PaymentService.PayMemberPower", ex);
            }
        }
    }
}
