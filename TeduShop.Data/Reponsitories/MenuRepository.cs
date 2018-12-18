using TeduShop.Data.Infrastructure;
using TeduShop.Model.Model;

namespace TeduShop.Data.Reponsitories
{
    public interface IMenuRepository
    {
    }
    public class MenuRepository: ReponsitoryBase<Menu>, IMenuRepository
    {
        public MenuRepository(IDBFactory dBFactory) : base(dBFactory)
        {

        }
    }
}
