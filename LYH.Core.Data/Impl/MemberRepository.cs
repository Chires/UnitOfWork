using LYH.Core.Data.Models;
using LYH.Core.Data.Repositories;
using LYH.Infrastructure.Data.EF;
using System.ComponentModel.Composition;

namespace LYH.Core.Data.Impl
{
    /// <summary>
    ///     仓储操作实现——用户信息
    /// </summary>
    [Export(typeof(IMemberRepository))]
    public class MemberRepository : EFRepositoryBase<Member>, IMemberRepository
    {
    }




}
