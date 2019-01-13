using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Model;

namespace TeduShop.Data.Reponsitories
{
	public interface IFeedbackRepository : IReponsitory<Feedback>
	{
	}
	public class FeedbackRepository : ReponsitoryBase<Feedback>, IFeedbackRepository
	{
		public FeedbackRepository(IDBFactory dBFactory) : base(dBFactory)
		{

		}
	}
}
