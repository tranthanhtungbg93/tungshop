using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Common;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Reponsitories;
using TeduShop.Model.Model;

namespace TeduShop.Service
{
	public interface ICommonService
	{
		Footer GetFooter();
	}
	public class CommonService : ICommonService
	{
		IFooterRepository _footerRepository;
		IUnitOfWork _unitOfWork;
		public CommonService(IFooterRepository footerRepository, IUnitOfWork unitOfWork)
		{
			_footerRepository = footerRepository;
			_unitOfWork = unitOfWork;
		}
		public Footer GetFooter()
		{
			return _footerRepository.GetSingleByCondition(x => x.ID == CommonConstant.DefaultFooterID);
		}
	}
}
