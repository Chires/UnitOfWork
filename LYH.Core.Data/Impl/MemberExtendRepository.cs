using LYH.Database.Core.Data.Models;
using LYH.Database.Core.Data.Repositories;
using LYH.Infrastructure.Data.EF;
using System.ComponentModel.Composition;

namespace LYH.Database.Core.Data.Impl
{
    /// <summary>
    ///     仓储操作实现——用户扩展信息
    /// </summary>
    [Export(typeof(IMemberExtendRepository))]
    public class MemberExtendRepository : EFRepositoryBase<MemberExtend>, IMemberExtendRepository { }
}
