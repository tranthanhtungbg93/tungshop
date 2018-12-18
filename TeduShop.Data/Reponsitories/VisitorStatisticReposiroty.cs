using TeduShop.Data.Infrastructure;
using TeduShop.Model.Model;

namespace TeduShop.Data.Reponsitories
{
    public interface IVisitorStatisticReposiroty
    {
    }
    public class VisitorStatisticReposiroty : ReponsitoryBase<VisitorStatistic>, IVisitorStatisticReposiroty
    {
        public VisitorStatisticReposiroty(IDBFactory dBFactory) : base(dBFactory)
        {

        }
    }
}
