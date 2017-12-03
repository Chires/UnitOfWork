using LYH.Application.Models;
using LYH.Infrastructure.Data.Commons.Extensions;
using LYH.Infrastructure.Data.Commons.Operations;
using LYH.Site.Core;
using LYH.Site.Core.Impl;
using System;
using System.ComponentModel.Composition;
using System.Web.Mvc;

namespace LYH.UnitOfWork.Site.Web.Controllers
{
    [Export]
    public class AccountController : Controller
    {
        #region 属性

        [Import]
        public IAccountSiteContract AccountSiteContract { get; set; }


        public AccountController()
        {
            AccountSiteContract = new AccountSiteContract();
        }



        #endregion

        #region 视图功能

        public ActionResult Login()
        {
            string returnUrl = Request.Params["returnUrl"];
            returnUrl = returnUrl ?? Url.Action("Index", "Home", new { area = "" });
            LoginModel model = new LoginModel
            {
                ReturnUrl = returnUrl
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            try
            {
                OperationResult result = AccountSiteContract.Login(model);
                string msg = result.Message ?? result.ResultType.GetDescription();
                if (result.ResultType == OperationResultType.Success)
                {
                    return Redirect(model.ReturnUrl);
                }
                ModelState.AddModelError("", msg);
                return View(model);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(model);
            }
        }

        public ActionResult Logout()
        {
            string returnUrl = Request.Params["returnUrl"];
            returnUrl = returnUrl ?? Url.Action("Index", "Home", new { area = "" });
            if (User.Identity.IsAuthenticated)
            {
                AccountSiteContract.Logout();
            }
            return Redirect(returnUrl);
        }

        #endregion
    }
}
