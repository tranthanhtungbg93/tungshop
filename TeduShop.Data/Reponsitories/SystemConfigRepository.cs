using TeduShop.Data.Infrastructure;
using TeduShop.Model.Model;

namespace TeduShop.Data.Reponsitories
{
    public interface ISystemConfigRepository
    {
    }
    public class SystemConfigRepository : ReponsitoryBase<SystemConfig>, ISystemConfigRepository
    {
        public SystemConfigRepository(IDBFactory dBFactory) : base(dBFactory)
        {

        }
    }
}
