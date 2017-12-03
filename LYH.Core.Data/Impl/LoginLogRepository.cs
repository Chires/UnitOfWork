using LYH.Core.Data.Models;
using LYH.Core.Data.Repositories;
using LYH.Infrastructure.Data.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LYH.Core.Data.Impl
{

    /// <summary>
    ///     仓储操作实现——日志信息
    /// </summary>
    [Export(typeof(ILoginLogRepository))]
    public abstract class LoginLogRepository : EFRepositoryBase<LoginLog>, ILoginLogRepository
    {
    }
}
