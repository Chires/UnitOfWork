using LYH.Database.Core.Data.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace LYH.Database.Core.Initialize
{
    public class UnitOfWorkInitializeData : CreateDatabaseIfNotExists<UnitOfWorkEntitiesDbContext>
    {

        protected override void Seed(UnitOfWorkEntitiesDbContext context)
        {
            List<Member> members = new List<Member>
            {
                                 new Member { UserName = "admin", PassWord= "123456", Email = "admin@gmfcn.net", NickName = "管理员" },
                 new Member { UserName = "gmfcn", PassWord= "123456", Email = "mf.guo@qq.com", NickName = "郭明锋" }
             };
            DbSet<Member> memberSet = context.Set<Member>();
            members.ForEach(m => memberSet.Add(m));
            context.SaveChanges();
        }

    }
}
