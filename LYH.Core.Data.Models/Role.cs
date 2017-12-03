using LYH.Infrastructure.Data.Commons.Helpers;
using LYH.Infrastructure.Data.DDD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LYH.Core.Data.Models
{
    /// <summary>
    /// 实体类——角色信息
    /// </summary>
    [Description("角色信息")]
    public class Role : BaseEntity
    {
        /// <summary>
        /// 初始化一个 角色实体类 的新实例
        /// </summary>
        public Role()
        {
            Id = CombHelper.NewComb();
        }

        /// <summary>
        /// 获取或设置 角色编号
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 获取或设置 角色名称
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置 角色描述
        /// </summary>
        [StringLength(100)]
        public string Description { get; set; }

        /// <summary>
        /// 获取或设置 角色类型
        /// </summary>
        public RoleType RoleType { get; set; }

        /// <summary>
        /// 获取或设置 拥有此角色的用户信息集合
        /// </summary>
        public virtual ICollection<Member> Members { get; set; }
    }

    /// <summary>
    /// 表示角色类型的枚举
    /// </summary>
    [Description("角色类型")]
    public enum RoleType
    {
        /// <summary>
        /// 用户类型
        /// </summary>
        [Description("用户角色")]
        User,

        /// <summary>
        /// 管理员类型
        /// </summary>
        [Description("管理角色")]
        Admin
    }


}
