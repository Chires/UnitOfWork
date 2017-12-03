using LYH.Infrastructure.Data.Commons.Helpers;
using LYH.Infrastructure.Data.DDD;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LYH.Core.Data.Models
{
    /// <summary>
    ///     登录信息类
    /// </summary>
    public class LoginInfo
    {
        /// <summary>
        ///     获取或设置 登录账号
        /// </summary>
        public string Access { get; set; }
          
        /// <summary>
        ///     获取或设置 登录密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        ///     获取或设置 IP地址
        /// </summary>
        public string IpAddress { get; set; }
    }



    /// <summary>
    /// 实体类——登录记录信息
    /// </summary>
    [Description("登录记录信息")]
    public class LoginLog : BaseEntity
    {
        /// <summary>
        /// 初始化一个 登录记录实体类 的新实例
        /// </summary>
        public LoginLog()
        {
            Id = CombHelper.NewComb();
        }

        /// <summary>
        /// 获取或设置 登录记录编号
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 获取或设置 登录IP地址
        /// </summary>
        [Required]
        [StringLength(15)]
        public string IpAddress { get; set; }

        /// <summary>
        /// 获取或设置 用户信息
        /// </summary>
        public virtual Member Member { get; set; }
    }


}
