using LYH.Infrastructure.Data.Commons.Helpers;
using LYH.Infrastructure.Data.DDD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LYH.Database.Core.Data.Models
{

    /// <summary>
    ///  实体类——用户信息
    /// </summary>
    [Description("用户信息")]
    public class Member : BaseEntity
    {
        /// <summary>
        /// 获取或设置 用户编号
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// 获取或设置 用户名
        /// </summary>
        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        /// <summary>
        /// 获取或设置 密码
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        /// <summary>
        /// 获取或设置 用户昵称
        /// </summary>
        [Required]
        [StringLength(20)]
        public string NickName { get; set; }


        /// <summary>
        /// 获取或设置 用户邮箱
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Email { get; set; }

        /// <summary>
        ///  获取或设置 用户扩展信息
        /// </summary>
        public virtual MemberExtend Extend { get; set; }

        /// <summary>
        /// 获取或设置 用户拥有的角色信息集合
        /// </summary>
        public virtual ICollection<Role> Roles { get; set; }

        /// <summary>
        /// 获取或设置 用户登录记录集合
        /// </summary>
        public virtual ICollection<LoginLog> LoginLogs { get; set; }


    }


    /// <summary>
    /// 实体类——用户扩展信息
    /// </summary>
    [Description("用户扩展信息")]
    public class MemberExtend : BaseEntity
    {
        /// <summary>
        /// 初始化一个 用户扩展实体类 的新实例
        /// </summary>
        public MemberExtend()
        {
            Id = CombHelper.NewComb();
        }

        /// <summary>
        /// 获取或设置 编号
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 获取或设置 用户信息
        /// </summary>
        [Required]
        public virtual Member Member { get; set; }

    }

}
