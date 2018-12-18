using TeduShop.Data.Infrastructure;
using TeduShop.Model.Model;

namespace TeduShop.Data.Reponsitories
{
    public interface IPageRepository
    {
    }
    public class PageRepository : ReponsitoryBase<Page>, IPageRepository
    {
        public PageRepository(IDBFactory dBFactory) : base(dBFactory) 
        {

        }
    }
}
