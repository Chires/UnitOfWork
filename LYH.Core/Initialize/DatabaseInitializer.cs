namespace LYH.Database.Core.Initialize
{
    /// <summary>
    /// 数据库初始化操作类
    /// </summary>
    public static class DatabaseInitializer
    {
        /// <summary>
        /// 数据库初始化
        /// </summary>
        public static void Initialize()
        {
            System.Data.Entity.Database.SetInitializer(new UnitOfWorkInitializeData());
            using (var db = new UnitOfWorkEntitiesDbContext())
            {
                db.Database.Initialize(false);
            }
        }
    }
}
