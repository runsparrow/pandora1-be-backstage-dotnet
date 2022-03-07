using Microsoft.AspNetCore.Hosting;
using MISApi.CacheServices.WFM;
using MISApi.Dal.EF;
using MISApi.Entities.CMS;
using MISApi.Entities.WFM;
using MISApi.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MISApi.Services.CMS
{
    /// <summary>
    ///
    /// </summary>
    public class CardService
    {
        #region CreateService

        /// <summary>
        /// CreateService
        /// </summary>
        public class CreateService : Base.CardService.CreateService
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

            /// <summary>
            /// 创建指定状态
            /// </summary>
            /// <param name="entity"></param>
            /// <param name="statusKey"></param>
            /// <returns></returns>
            public virtual Card ToStatus(Card entity, string statusKey)
            {
                try
                {
                    // 定义
                    Card result = new Card();
                    // 事务
                    transService.TransRegist(delegate
                    {
                        Status status = new StatusCacheService.RowService().ByKey(statusKey);
                        entity.StatusId = status.Id;
                        entity.StatusValue = status.Value;
                        entity.StatusName = status.Name;
                        result = base.Create(entity);
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.CardService.CreateService.ToStatus", ex);
                }
            }

            /// <summary>
            /// 批量创建指定状态
            /// </summary>
            /// <param name="entities"></param>
            /// <param name="statusKey"></param>
            /// <returns></returns>
            public virtual List<Card> BatchToStatus(List<Card> entities, string statusKey)
            {
                try
                {
                    // 定义
                    List<Card> results = new List<Card>();
                    // 事务
                    transService.TransRegist(delegate
                    {
                        // 遍历
                        entities.ForEach(entity =>
                        {
                            results.Add(new CardService.CreateService().ToStatus(entity, statusKey));
                        });
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return results;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.CardService.CreateService.BatchToStatus", ex);
                }
            }
        }

        #endregion CreateService

        #region UpdateService

        /// <summary>
        /// UpdateService
        /// </summary>
        public class UpdateService : Base.CardService.UpdateService
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

            /// <summary>
            /// 编辑指定状态
            /// </summary>
            /// <param name="entity"></param>
            /// <param name="statusKey"></param>
            /// <returns></returns>
            public virtual Card ToStatus(Card entity, string statusKey)
            {
                try
                {
                    // 定义
                    Card result = new Card();
                    // 事务
                    transService.TransRegist(delegate
                    {
                        Status status = new StatusCacheService.RowService().ByKey(statusKey);
                        entity.StatusId = status.Id;
                        entity.StatusValue = status.Value;
                        entity.StatusName = status.Name;
                        result = base.Update(entity);
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.CardService.UpdateService.ToStatus", ex);
                }
            }

            /// <summary>
            /// 批量编辑指定状态
            /// </summary>
            /// <param name="entities"></param>
            /// <param name="statusKey"></param>
            /// <returns></returns>
            public virtual List<Card> BatchToStatus(List<Card> entities, string statusKey)
            {
                try
                {
                    // 定义
                    List<Card> results = new List<Card>();
                    // 事务
                    transService.TransRegist(delegate
                    {
                        // 遍历
                        entities.ForEach(entity =>
                        {
                            results.Add(new CardService.UpdateService().ToStatus(entity, statusKey));
                        });
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return results;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.CardService.UpdateService.BatchToStatus", ex);
                }
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="c"></param>
            /// <param name="m"></param>
            /// <returns></returns>
            public virtual Card Activate(Card c, Member m)
            {
                try
                {
                    // 定义
                    Card result = new Card();
                    // 事务
                    transService.TransRegist(delegate
                    {
                        // 更新卡信息
                        var card = new CardService.RowService().ById(c.Id);
                        if (card != null)
                        {
                            card.IsActivate = true;
                            card.ActivateMemberId = m.Id;
                            card.ActivateMemberName = m.Name;
                        }
                        result = new CardService.UpdateService().Execute(card);
                        // 更新会员信息
                        var member = new MemberService.RowService().ById(m.Id);
                        if (member != null)
                        {
                            member.UploadCount = card.UploadLimit == -1 ? -1 : member.UploadCount + card.UploadLimit;
                            member.DownCount = card.DownLimit == -1 ? -1 : member.DownCount + card.DownLimit;
                            member.BuyCount = card.BuyLimit == -1 ? -1 : member.BuyCount + card.BuyLimit;
                            member.LevelDeadline = member.LevelDeadline < DateTime.Now ? DateTime.Now : member.LevelDeadline;
                            member.LevelDeadline = member.LevelDeadline.Value.AddDays(card.DaysLimit ?? 0);
                        }
                        new MemberService.UpdateService().Execute(member);
                    });
                    // 提交
                    transService.TransCommit();
                    // 返回
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Services.CMS.CardService.UpdateService.BatchToStatus", ex);
                }
            }

            /// <summary>
            ///
            /// </summary>
            public string RMS(IWebHostEnvironment environment)
            {
                Stream stream = NPOIHelper.CreateFileStreamFromTemplate($"{environment.WebRootPath}\\Template\\Card.xls");
                // 查询
                var cardList = new CardService.RowsService().Page(
                    new HttpClients.HttpModes.BaseMode.KeyWord(""),
                    new HttpClients.HttpModes.BaseMode.Join[] { new HttpClients.HttpModes.BaseMode.Join("") },
                    new HttpClients.HttpModes.BaseMode.Page(1, 10000),
                    null,
                    null,
                    new HttpClients.HttpModes.BaseMode.Status(1, 2)
                );
                // 循环
                for (int index = 0; index < cardList.Count; index++)
                {
                    stream = NPOIHelper.CreateRow(stream, 0, index + 1,
                            new NPOIHelper.Cell { Index = 0, Value = cardList[index].CardNo },
                            new NPOIHelper.Cell { Index = 1, Value = cardList[index].CardPrefix },
                            new NPOIHelper.Cell { Index = 2, Value = cardList[index].CardDate.ToString() },
                            new NPOIHelper.Cell { Index = 3, Value = cardList[index].DaysLimit },
                            new NPOIHelper.Cell { Index = 4, Value = cardList[index].IsActivate.Value ? "是" : "否" },
                            new NPOIHelper.Cell { Index = 5, Value = cardList[index].ActivateMemberName }
                        );
                }
                // 文件路径
                string filePath = $"{environment.WebRootPath}\\Result\\{DateTime.Now.ToString("yyyyMMdd")}_Card.xls";
                // 创建文件
                NPOIHelper.WriteSteamToFile(filePath, (MemoryStream)stream);
                // 返回
                return filePath;
            }
        }

        #endregion UpdateService

        #region DeleteService

        /// <summary>
        /// DeleteService
        /// </summary>
        public class DeleteService : Base.CardService.DeleteService
        {
        }

        #endregion DeleteService

        #region ColumnsService

        /// <summary>
        /// ColumnsMode Service
        /// </summary>
        public class ColumnsService : Base.CardService.ColumnsService
        {
        }

        #endregion ColumnsService

        #region RowService

        /// <summary>
        ///
        /// </summary>
        public class RowService : Base.CardService.RowService
        {
            /// <summary>
            ///
            /// </summary>
            /// <param name="cardNo"></param>
            /// <param name="cardPassword"></param>
            /// <returns></returns>
            public Card Verify(string cardNo, string cardPassword)
            {
                using (PandoraContext context = new PandoraContext())
                {
                    try
                    {
                        return SQLEntityToSingle(
                            SQLQueryable(context)
                                .SingleOrDefault(row => (
                                    (row.Card.CardNo == cardNo && row.Card.CardPassword == cardPassword)
                                ) && row.Card.IsActivate == false)
                        );
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MISApi.Services.CMS.CardService.RowService.Verify", ex);
                    }
                }
            }
        }

        #endregion RowService

        #region RowsService

        /// <summary>
        ///
        /// </summary>
        public class RowsService : Base.CardService.RowsService
        {
        }

        #endregion RowsService
    }
}