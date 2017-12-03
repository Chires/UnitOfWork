using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LYH.Application.Models
{
    /// <summary>
    /// 用户登录模型
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// 获取或设置 登录账号
        /// </summary>
        [Required]
        public string Account { get; set; }

        /// <summary>
        /// 获取或设置 登录密码
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// 获取或设置 是否记住登录
        /// </summary>
        public bool IsRememberLogin { get; set; }

        /// <summary>
        /// 获取或设置 登录成功后返回地址
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}
