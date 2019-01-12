using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Model;

namespace TeduShop.Data.Reponsitories
{
	public interface IContactDetailRepository : IReponsitory<ThongTinLienLac>
	{
	}
	public class ContactDetailRepository : ReponsitoryBase<ThongTinLienLac>, IContactDetailRepository
	{
		public ContactDetailRepository(IDBFactory dBFactory) : base(dBFactory)
		{

		}
	}
}
