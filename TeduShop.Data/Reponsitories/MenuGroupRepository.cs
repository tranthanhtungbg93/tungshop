using TeduShop.Data.Infrastructure;
using TeduShop.Model.Model;

namespace TeduShop.Data.Reponsitories
{
    public interface IMenuGroupRepository : IReponsitory<MenuGroup>
    {
    }
    public class MenuGroupRepository : ReponsitoryBase<MenuGroup>, IMenuGroupRepository
    {
        public MenuGroupRepository(IDBFactory dBFactory) : base(dBFactory)
        {

        }
    }
}
