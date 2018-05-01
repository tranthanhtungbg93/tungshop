using System;

namespace TeduShop.Data.Infrastructure
{
    public interface IDBFactory : IDisposable
    {
        TeduShopDbContext Init();
    }
}
