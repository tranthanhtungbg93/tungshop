using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Reponsitories;
using TeduShop.Model.Model;

namespace TeduShop.Service
{
	public interface IContactDetailService
	{
		ThongTinLienLac GetDefaultContact();
	}
	public class ContactDetailService : IContactDetailService
	{
		public IUnitOfWork _unitOfWork;
		public IContactDetailRepository _contactDetailRepository;
		public ContactDetailService(IUnitOfWork unitOfWork, IContactDetailRepository contactDetailRepository)
		{
			_contactDetailRepository = contactDetailRepository;
			_unitOfWork = unitOfWork;
		}
		public ThongTinLienLac GetDefaultContact()
		{
			return _contactDetailRepository.GetSingleByCondition(x => x.TrangThai);
		}
	}
}
