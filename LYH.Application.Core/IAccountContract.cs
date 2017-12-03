using LYH.Core.Data.Models;
using LYH.Infrastructure.Data.Commons.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LYH.Application.Core
{
    /// <summary>
    ///     账户模块核心业务契约
    /// </summary>
   public interface IAccountContract
    {
        #region 属性

        #endregion

        #region 公共方法

        /// <summary>
        ///     用户登录
        /// </summary>
        /// <param name="loginInfo">登录信息</param>
        /// <returns>业务操作结果</returns>
        OperationResult Login(LoginInfo loginInfo);

        #endregion
    }
}
