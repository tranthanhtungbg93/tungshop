using TeduShop.Data.Infrastructure;
using TeduShop.Model.Model;

namespace TeduShop.Data.Reponsitories
{
    public interface ISupportOnlineRepository : IReponsitory<SupportOnline>
    {
    }
    public class SupportOnlineRepository : ReponsitoryBase<SupportOnline>, ISupportOnlineRepository
    {
        public SupportOnlineRepository(IDBFactory dBFactory) : base(dBFactory)
        {

        }
    }
}
