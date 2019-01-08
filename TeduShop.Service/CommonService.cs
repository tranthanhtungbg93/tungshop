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
		IEnumerable<Slide> GetSlides();
	}
	public class CommonService : ICommonService
	{
		IFooterRepository _footerRepository;
		IUnitOfWork _unitOfWork;
		ISlideRepository _slideRepository;

		public CommonService(IFooterRepository footerRepository, IUnitOfWork unitOfWork, ISlideRepository slideRepository)
		{
			_footerRepository = footerRepository;
			_unitOfWork = unitOfWork;
			_slideRepository = slideRepository;
		}
		public Footer GetFooter()
		{
			return _footerRepository.GetSingleByCondition(x => x.ID == CommonConstant.DefaultFooterID);
		}

		public IEnumerable<Slide> GetSlides()
		{
			return _slideRepository.GetMulti(x => x.Status == true);
		}
	}
}
