using TeduShop.Data.Infrastructure;
using TeduShop.Model.Model;

namespace TeduShop.Data.Reponsitories
{
    public interface IVisitorStatisticReposiroty : IReponsitory<VisitorStatistic>
    {
    }
    public class VisitorStatisticReposiroty : ReponsitoryBase<VisitorStatistic>, IVisitorStatisticReposiroty
    {
        public VisitorStatisticReposiroty(IDBFactory dBFactory) : base(dBFactory)
        {

        }
    }
}
