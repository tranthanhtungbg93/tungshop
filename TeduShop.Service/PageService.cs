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
	public interface IPageService
	{
		Page GetbyAlias(string alias);
	}
	public class PageService : IPageService
	{
		IPageRepository _pageRepository;
		IUnitOfWork _unitOfWork;
		public PageService(IPageRepository pageRepository, IUnitOfWork unitOfWork)
		{
			_pageRepository = pageRepository;
			_unitOfWork = unitOfWork;
		}
		public Page GetbyAlias(string alias)
		{
			return _pageRepository.GetSingleByCondition(x => x.Alias == alias);
		}
	}
}
