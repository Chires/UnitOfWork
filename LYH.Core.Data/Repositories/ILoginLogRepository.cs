using LYH.Core.Data.Models;
using LYH.Infrastructure.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LYH.Core.Data.Repositories
{
    /// <summary>
    /// 用户登录的日志
    /// </summary>
    public interface ILoginLogRepository : IRepository<LoginLog> { }

}
