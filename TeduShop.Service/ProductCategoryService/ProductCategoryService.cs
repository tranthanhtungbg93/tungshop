using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Reponsitories;
using TeduShop.Model.Model;

namespace TeduShop.Service.ProductCategoryService
{
	public class ProductCategoryService : IProductCategoryService
	{
		IUnitOfWork _unitOfWork;
		IProductCategoryRespository _productCategoryRepository;


		public ProductCategoryService(IProductCategoryRespository productCategoryRepository, IUnitOfWork unitOfWork)
		{
			_productCategoryRepository = productCategoryRepository;
			_unitOfWork = unitOfWork;
		}

		public ProductCategory Add(ProductCategory category)
		{
			return _productCategoryRepository.Add(category);
		}

		public ProductCategory Delete(int id)
		{
			return _productCategoryRepository.Delete(id);
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<ProductCategory> GetAll()
		{
			return _productCategoryRepository.GetAll();
		}

		public IEnumerable<ProductCategory> GetAll(string keyword)
		{
			if (!string.IsNullOrEmpty(keyword))
			{
				return _productCategoryRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
			}
			return _productCategoryRepository.GetAll();
		}

		public IEnumerable<ProductCategory> GetAllbyParentID(int parentId)
		{
			return _productCategoryRepository.GetMulti(x => x.Status && x.ParentID == parentId);
		}

		public ProductCategory GetById(int id)
		{
			return _productCategoryRepository.GetSingleById(id);
		}

		public void SaveChange()
		{
			_unitOfWork.Commit();
		}

		public void Update(ProductCategory category)
		{
			_productCategoryRepository.Update(category);
		}
	}
}
