using TeduShop.Data.Infrastructure;
using TeduShop.Model.Model;

namespace TeduShop.Data.Reponsitories
{
    public interface ISlideRepository
    {
    }
    public class SlideRepository : ReponsitoryBase<Slide>, ISlideRepository
    {
        public SlideRepository(IDBFactory dBFactory) : base(dBFactory)
        {

        }
    }
}
