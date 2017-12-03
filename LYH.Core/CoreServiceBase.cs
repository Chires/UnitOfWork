using LYH.Infrastructure.Data.DDD;
using System.ComponentModel.Composition;

namespace LYH.Database.Core
{
    /// <summary>
    /// 核心业务实现基类
    /// </summary>
    public abstract class CoreServiceBase
      {
          /// <summary>
          /// 获取或设置 工作单元对象，用于处理同步业务的事务操作
          /// </summary>
          [Import]
          protected IUnitOfWork UnitOfWork { get; set; }
      }
}
