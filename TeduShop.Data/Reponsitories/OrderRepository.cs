using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Model;

namespace TeduShop.Data.Reponsitories
{
    public interface IOrderRepository : IReponsitory<Order>
    {
    }
    public class OrderRepository : ReponsitoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDBFactory dBFactory) : base(dBFactory)
        {

        }
    }
}
