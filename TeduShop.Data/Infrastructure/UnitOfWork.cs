using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeduShop.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDBFactory dbFactory;
        private TeduShopDbContext dbContext;

        public UnitOfWork(IDBFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }
        public TeduShopDbContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }
        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}
