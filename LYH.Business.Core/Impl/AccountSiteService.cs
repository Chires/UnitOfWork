﻿using LYH.Application.Core.Impl;
using LYH.Application.Models;
using LYH.Database.Core.Data.Models;
using LYH.Infrastructure.Data.Commons.Helpers;
using LYH.Infrastructure.Data.Commons.Operations;
using System;
using System.ComponentModel.Composition;
using System.Web;
using System.Web.Security;

namespace LYH.Site.Core.Impl
{

    /// <summary>
    ///     账户模块站点业务实现
    /// </summary>
    [Export(typeof(IAccountSiteContract))]
    public class AccountSiteService : AccountContract, IAccountSiteContract
    {
        /// <summary>
        ///     用户登录
        /// </summary>
        /// <param name="model">登录模型信息</param>
        /// <returns>业务操作结果</returns>
        public OperationResult Login(LoginModel model)
        {
            PublicHelper.CheckArgument(model, "model");
            LoginInfo loginInfo = new LoginInfo
            {
                Access = model.Account,
                Password = model.Password,
                IpAddress = HttpContext.Current.Request.UserHostAddress
            };
            OperationResult result = base.Login(loginInfo);
            if (result.ResultType == OperationResultType.Success)
            {
                Member member = (Member)result.AppendData;
                DateTime expiration = model.IsRememberLogin
                    ? DateTime.Now.AddDays(7)
                    : DateTime.Now.Add(FormsAuthentication.Timeout);
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, member.UserName, DateTime.Now, expiration,
                    true, member.NickName, FormsAuthentication.FormsCookiePath);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
                if (model.IsRememberLogin)
                {
                    cookie.Expires = DateTime.Now.AddDays(7);
                }
                HttpContext.Current.Response.Cookies.Set(cookie);
                result.AppendData = null;
            }
            return result;
        }

        /// <summary>
        ///     用户退出
        /// </summary>
        public void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}
