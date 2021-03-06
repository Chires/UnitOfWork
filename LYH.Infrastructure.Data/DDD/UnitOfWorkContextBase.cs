﻿using LYH.Infrastructure.Data.Commons.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LYH.Infrastructure.Data.DDD
{

    /// <summary>
    /// 单元的处理核心类
    /// </summary>
    public abstract class UnitOfWorkContextBase : IUnitOfWorkContext
    {
        #region 属性


        /// <summary>
        /// 获取 当前使用的数据访问上下文对象
        /// </summary>
        protected abstract DbContext Context { get; }

        /// <summary>
        ///     获取 当前单元操作是否已被提交
        /// </summary>
        public bool IsCommitted { get; private set; }

        #endregion

        #region  方法

        #region 提交当前单元操作的结果
        /// <summary>
        ///     提交当前单元操作的结果
        /// </summary>
        /// <returns></returns>
        public int Commit()
        {
            if (IsCommitted)
            {
                return 0;
            }
            try
            {
                int result = Context.SaveChanges();
                IsCommitted = true;
                return result;
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException != null && e.InnerException.InnerException is SqlException)
                {
                    SqlException sqlEx = e.InnerException.InnerException as SqlException;
                    string msg = DbInfoHelper.GetSqlExceptionMessage(sqlEx.Number);
                    throw PublicHelper.ThrowDataAccessException("提交数据更新时发生异常：" + msg, sqlEx);
                }
                throw;
            }
        }
        #endregion

        #region 资源的释放
        /// <summary>
        /// 资源的释放
        /// </summary>
        public void Dispose()
        {
            if (!IsCommitted)
            {
                Commit();
            }
            Context.Dispose();
        }
        #endregion

        #region 把当前单元操作回滚成未提交状态
        /// <summary>
        ///      把当前单元操作回滚成未提交状态
        /// </summary>
        public void RollBack()
        {
            IsCommitted = false;
        }
        #endregion

        #region 为指定的类型返回
        /// <summary>
        ///   为指定的类型返回 System.Data.Entity.DbSet，这将允许对上下文中的给定实体执行 CRUD 操作。
        /// </summary>
        /// <typeparam name="TEntity"> 应为其返回一个集的实体类型。 </typeparam>
        /// <returns> 给定实体类型的 System.Data.Entity.DbSet 实例。 </returns>
        public DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return Context.Set<TEntity>();
        }
        #endregion

        #region 注册一个新的对象到仓储上下文中
        /// <summary>
        ///     注册一个新的对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity"> 要注册的类型 </typeparam>
        /// <param name="entity"> 要注册的对象 </param>
        public void RegisterNew<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            //判断当前的实体
            EntityState entityState = Context.Entry(entity).State;
            if (entityState == EntityState.Detached)
            {
                //表示【Added】添加的操作
                Context.Entry(entity).State = EntityState.Added;
            }
            IsCommitted = false;
        }
        #endregion

        #region 批量注册多个新的对象到仓储上下文中
        /// <summary>
        ///     批量注册多个新的对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity"> 要注册的类型 </typeparam>
        /// <param name="entities"> 要注册的对象集合 </param>
        public void RegisterNew<TEntity>(IEnumerable<TEntity> entities) where TEntity : BaseEntity
        {
            try
            {
                // Context.Configuration.AutoDetectChangesEnabled 设置为false的时候数据库的修改是无效的
                //确保执行之后能为true
                Context.Configuration.AutoDetectChangesEnabled = false;
                foreach (TEntity entity in entities)
                {
                    RegisterNew(entity);
                }
            }
            finally
            {
                //注意这里
                Context.Configuration.AutoDetectChangesEnabled = true;
            }
        }
        #endregion

        #region 注册一个更改的对象到仓储上下文中
        /// <summary>
        ///     注册一个更改的对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity"> 要注册的类型 </typeparam>
        /// <param name="entity"> 要注册的对象 </param>
        public void RegisterModified<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            //判断该实体是否存在
            EntityState entityState = Context.Entry(entity).State;
            if (entityState == EntityState.Detached)
            {
                Context.Set<TEntity>().Attach(entity);
            }
            //修改实体的状态为---修改
            Context.Entry(entity).State = EntityState.Modified;
            //禁止提交
            IsCommitted = false;
        }
        #endregion

        #region 注册一个删除的对象到仓储上下文中
        /// <summary>
        ///   注册一个删除的对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity"> 要注册的类型 </typeparam>
        /// <param name="entity"> 要注册的对象 </param>
        public void RegisterDeleted<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            //直接改变实体的状态的为删除
            Context.Entry(entity).State = EntityState.Deleted;
            IsCommitted = false;
        }
        #endregion

        #region 批量注册多个删除的对象到仓储上下文中
        /// <summary>
        ///   批量注册多个删除的对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity"> 要注册的类型 </typeparam>
        /// <param name="entities"> 要注册的对象集合 </param>
        public void RegisterDeleted<TEntity>(IEnumerable<TEntity> entities) where TEntity : BaseEntity
        {
            try
            {
                Context.Configuration.AutoDetectChangesEnabled = false;
                foreach (TEntity entity in entities)
                {
                    RegisterDeleted(entity);
                }
            }
            finally
            {
                Context.Configuration.AutoDetectChangesEnabled = true;
            }
        }
        #endregion

        #endregion
    }
}
