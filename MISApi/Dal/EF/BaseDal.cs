﻿using Microsoft.EntityFrameworkCore;
using MISApi.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace MISApi.Dal.EF
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TContext"></typeparam>
    public abstract class BaseDal<T, TContext>
        where T : class
        where TContext : DbContext, new()
    {

        #region CRUD

        #region Column
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual T Columns()
        {
            using (TContext context = new TContext())
            {
                try
                {
                    return DbSetEntity(context).Find(0);
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Dal.EF.BaseDal.Columns", ex);
                }
            }
        }
        #endregion

        #region Read
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual List<T> Read()
        {
            using (TContext context = new TContext())
            {
                try
                {
                    return DbSetEntity(context).ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Dal.EF.BaseDal.Read", ex);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T Read(int id)
        {
            using (TContext context = new TContext())
            {
                try
                {
                    return DbSetEntity(context).Find(id);
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Dal.EF.BaseDal.Read", ex);
                }
            }
        }
        #endregion

        #region Create
        /// <summary>
        ///  添加单条记录
        /// </summary>
        /// <param name="entity"></param>
        public virtual T Create(T entity)
        {
            using (TContext context = new TContext())
            {
                try
                {
                    // 设置默认值
                    MethodInfo m = entity.GetType().GetMethod("DefaultValue", BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
                    if(m != null)
                    {
                        entity = (T)m.Invoke(entity, new object[] { entity });
                    }
                    PropertyInfo p = entity.GetType().GetProperty("Id");
                    if (p != null)
                    {
                        p.SetValue(entity, 0);
                    }
                    DbSetEntity(context).Add(entity);
                    context.SaveChanges();
                    return entity;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Dal.EF.BaseDal.Create", ex);
                }
            }
        }
        /// <summary>
        /// 添加多条记录
        /// </summary>
        /// <param name="entities"></param>
        public virtual List<T> Create(List<T> entities)
        {
            using (TContext context = new TContext())
            {
                try
                {
                    for(var i=0; i<entities.Count; i++)
                    {
                        // 设置默认值
                        MethodInfo m = entities[i].GetType().GetMethod("DefaultValue", BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
                        if (m != null)
                        {
                            entities[i] = (T)m.Invoke(entities[i], new object[] { entities[i] });
                        }
                    }
                    DbSetEntity(context).AddRange(entities);
                    context.SaveChanges();
                    return entities;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Dal.EF.BaseDal.Create", ex);
                }
            }
        }
        #endregion

        #region Update

        /// <summary>
        ///  根据 id 更新单条记录
        ///  EntityFramework 下 Update 封装
        /// </summary>
        /// <param name="entity"></param>
        public virtual T Update(T entity)
        {
            using (TContext context = new TContext())
            {
                try
                {
                    T dbEntity = DbSetEntity(context).Find(EntityPropertyValue(entity, "Id"));
                    if(dbEntity != null)
                    {
                        dbEntity.MergeFrom(entity);
                        context.Entry(dbEntity).State = EntityState.Modified;
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("未发现指定Id的记录！");
                    }
                    return dbEntity;
                }
                catch(Exception ex)
                {
                    throw new Exception("MISApi.Dal.EF.BaseDal.Update", ex);
                }
            }
        }
        /// <summary>
        ///  根据 id 更新多条记录
        ///  EntityFramework 下 Update 封装
        /// </summary>
        /// <param name="entities"></param>
        public virtual List<T> Update(List<T> entities)
        {
            using (TContext context = new TContext())
            {
                try
                {
                    foreach (var entity in entities)
                    {
                        T dbEntity = DbSetEntity(context).Find(EntityPropertyValue(entity, "Id"));
                        dbEntity.MergeFrom(entity);
                        context.Entry(dbEntity).State = EntityState.Modified;
                    }
                    context.SaveChanges();
                    return entities;
                }
                catch(Exception ex)
                {
                    throw new Exception("MISApi.Dal.EF.BaseDal.Update", ex);
                }
            }
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除单条记录【过时，准备删除】
        /// </summary>
        /// <param name="id"></param>
        public virtual T Delete(int id)
        {
            using (TContext context = new TContext())
            {
                try
                {
                    T entity = DbSetEntity(context).Find(id);
                    if (entity != null)
                    {
                        DbSetEntity(context).Remove(entity);
                        context.SaveChanges();
                    }
                    return entity;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Dal.EF.BaseDal.Delete", ex);
                }
            }
        }
        /// <summary>
        /// 【过时，准备删除】
        /// </summary>
        /// <param name="ids"></param>
        public virtual List<T> Delete(int[] ids)
        {
            using (TContext context = new TContext())
            {
                try
                {
                    List<T> entities = new List<T>();
                    for (int i = 0; i < ids.Length; i++)
                    {
                        T entity = DbSetEntity(context).Find(ids[i]);
                        entities.Add(entity);
                    }
                    if (entities.Count > 0)
                    {
                        DbSetEntity(context).RemoveRange(entities);
                        context.SaveChanges();
                    }
                    return entities;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Dal.EF.BaseDal.Delete", ex);
                }
            }
        }
        /// <summary>
        /// 删除单条记录
        /// </summary>
        /// <param name="entity"></param>
        public virtual T Delete(T entity)
        {
            using (TContext context = new TContext())
            {
                try
                {
                    T deleteEntity = entity;
                    try
                    {
                        deleteEntity = DbSetEntity(context).Find(
                            (int)EntityPropertyValue(entity, "Id")
                        );
                    }
                    catch
                    {

                    }
                    if (deleteEntity != null)
                    {
                        DbSetEntity(context).Remove(deleteEntity);
                        context.SaveChanges();
                    }
                    return entity;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Dal.EF.BaseDal.Delete", ex);
                }
            }
        }
        /// <summary>
        /// 删除多条记录
        /// </summary>
        /// <param name="entities"></param>
        public virtual List<T> Delete(List<T> entities)
        {
            using (TContext context = new TContext())
            {
                try
                {
                    foreach (var entity in entities)
                    {
                        T deleteEntity = entity;
                        try
                        {
                            deleteEntity = DbSetEntity(context).Find(
                                (int)EntityPropertyValue(entity, "Id")
                            );
                        }
                        catch
                        {

                        }
                        if (deleteEntity != null)
                        {
                            DbSetEntity(context).Remove(deleteEntity);
                        }
                    }
                    context.SaveChanges();
                    return entities;
                }
                catch (Exception ex)
                {
                    throw new Exception("MISApi.Dal.EF.BaseDal.Delete", ex);
                }
            }
        }
        #endregion

        #endregion

        #region Common

        #region Protected
        /// <summary>
        /// 从 TContext 中获取 T 数据集合
        /// </summary>
        /// <returns>TContext.T</returns>
        protected DbSet<T> DbSetEntity(TContext context)
        {
            try
            {
                PropertyInfo p = context.GetType().GetProperty(typeof(T).CustomAttributes.ElementAt(1).ConstructorArguments[0].Value.ToString());
                if (p == null)
                {
                    throw new Exception("Not found this property");
                }
                return (DbSet<T>)p.GetValue(context);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Dal.EF.BaseDal.DbSetEntity", ex);
            }
        }

        /// <summary>
        /// 从 Model 中获取 属性值
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyName"></param>
        /// <returns>T.Property.Value</returns>
        protected object EntityPropertyValue(T entity, string propertyName)
        {
            try
            {
                PropertyInfo p = entity.GetType().GetProperty(propertyName);
                if (p == null)
                {
                    throw new Exception("Not found this property");
                }
                return p.GetValue(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Dal.EF.BaseDal.EntityPropertyValue", ex);
            }
        }

        /// <summary>
        /// 从 Model 中获取 属性值
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <returns>T.Property.Value</returns>
        protected void SetEntityPropertyValue(T entity, string propertyName, object value)
        {
            try
            {
                PropertyInfo p = entity.GetType().GetProperty(propertyName);
                if (p == null)
                {
                    throw new Exception("Not found this property");
                }
                p.SetValue(entity, value);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Dal.EF.BaseDal.SetEntityPropertyValue", ex);
            }
        }
        /// <summary>
        /// 从一个对象信息生成Json串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected static string ObjectToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        /// <summary>
        /// 从一个Json串生成对象信息
        /// </summary>
        /// <param name="jsonString"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected static object JsonToObject(string jsonString, object obj)
        {
            return JsonConvert.DeserializeObject(jsonString, obj.GetType());
        }

        /// <summary>
        /// 字段类型decimal的合计方法
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="queryable"></param>
        /// <param name="entityAttrs"></param>
        /// <returns></returns>
        protected decimal Sum<SQLEntity>(Expression<Func<SQLEntity, decimal>> selector, IQueryable<SQLEntity> queryable, params string[] entityAttrs)
        {
            try
            {
                return queryable.Sum(selector);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Dal.EF.BaseDal.Sum", ex);
            }
        }
        /// <summary>
        /// 字段类型int的合计方法
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="queryable"></param>
        /// <param name="entityAttrs"></param>
        /// <returns></returns>
        protected int Sum<SQLEntity>(Expression<Func<SQLEntity, int>> selector, IQueryable<SQLEntity> queryable, params string[] entityAttrs)
        {
            try
            {
                return queryable.Sum(selector);
            }
            catch (Exception ex)
            {
                throw new Exception("MISApi.Dal.EF.BaseDal.Sum", ex);
            }
        }
        #endregion
        
        #endregion
    }
}
