
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Model;

namespace TeduShop.Data.Reponsitories
{
    public interface IFooterRepository : IReponsitory<Footer>
    {
    }
    public class FooterRepository : ReponsitoryBase<Footer>, IFooterRepository
    {
        public FooterRepository(IDBFactory dBFactory) : base(dBFactory)
        {

        }
    }
}
