using LYH.Infrastructure.Data.DDD;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LYH.Core
{

    /// <summary>
    ///     UnitOfWorkEntitiesContext项目单元操作类
    /// </summary>
    [Export(typeof(IUnitOfWork))]
    public class UnitOfWorkEntitiesContext : UnitOfWorkContextBase
    {

        /// <summary>
        ///     获取或设置 当前使用的数据访问上下文对象
        /// </summary>
        protected override DbContext Context
        {
            get
            {
                return UnitOfWorkEntitiesDbContext;
            }
        }

        /// <summary>
        ///     获取或设置 默认的Demo项目数据访问上下文对象
        /// </summary>
        [Import(typeof(DbContext))]
        public UnitOfWorkEntitiesDbContext UnitOfWorkEntitiesDbContext { get; set; }
    }
}
