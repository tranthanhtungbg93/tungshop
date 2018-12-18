using TeduShop.Data.Infrastructure;
using TeduShop.Model.Model;

namespace TeduShop.Data.Reponsitories
{
    public interface IOrderDetailRepository
    {
    }
    public class OrderDetailRepository : ReponsitoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(IDBFactory dBFactory) : base(dBFactory)
        {

        }
    }
}
