using LYH.Application.Core;
using LYH.Core;
using LYH.Core.Data.Models;
using LYH.Infrastructure.Data.Commons.Operations;
using LYH.Core.Data.Repositories;
using System.ComponentModel.Composition;
using LYH.Infrastructure.Data.Commons.Helpers;
using System.Linq;

namespace LYH.Application.Data
{

    /// <summary>
    ///     账户模块核心业务实现
    /// </summary>
    public abstract class AccountService : CoreServiceBase, IAccountContract
    {
        #region 受保护的属性

        /// <summary>
        /// 获取或设置 用户信息数据访问对象
        /// </summary>
        [Import]
        protected IMemberRepository MemberRepository { get; set; }

        /// <summary>
        /// 获取或设置 登录记录信息数据访问对象
        /// </summary>
        [Import]
        protected ILoginLogRepository LoginLogRepository { get; set; }

        #endregion

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="loginInfo">登录信息</param>
        /// <returns>业务操作结果</returns>

        public OperationResult Login(LoginInfo loginInfo)
        {
            PublicHelper.CheckArgument(loginInfo, "loginInfo");

            Member member = MemberRepository.Entities.SingleOrDefault(m => m.UserName == loginInfo.Access || m.Email == loginInfo.Access);

            if (member == null)
            {
                return new OperationResult(OperationResultType.QueryNull, "指定账号的用户不存在。");
            }

            if (member.PassWord != loginInfo.Password)
            {
                return new OperationResult(OperationResultType.Warning, "登录密码不正确。");
            }

            LoginLog loginLog = new LoginLog { IpAddress = loginInfo.IpAddress, Member = member };
                         LoginLogRepository.Insert(loginLog);
                         return new OperationResult(OperationResultType.Success, "登录成功。", member);
        }
    }
}
