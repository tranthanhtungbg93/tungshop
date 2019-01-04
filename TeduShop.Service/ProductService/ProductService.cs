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
	public class ProductService : IProductService
	{
		IUnitOfWork _unitOfWork;
		IProductRepository _productRepository;


		public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
		{
			_productRepository = productRepository;
			_unitOfWork = unitOfWork;
		}

		public Product Add(Product category)
		{
			return _productRepository.Add(category);
		}

		public Product Delete(int id)
		{
			return _productRepository.Delete(id);
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Product> GetAll()
		{
			return _productRepository.GetAll();
		}

		public IEnumerable<Product> GetAll(string keyword)
		{
			if (!string.IsNullOrEmpty(keyword))
			{
				return _productRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
			}
			return _productRepository.GetAll();
		}

		public IEnumerable<Product> GetAllbyCategoryID(int CategoryID)
		{
			return _productRepository.GetMulti(x => x.Status && x.CateforyID == CategoryID);
		}

		public Product GetById(int id)
		{
			return _productRepository.GetSingleById(id);
		}

		public void SaveChange()
		{
			_unitOfWork.Commit();
		}

		public void Update(Product category)
		{
			_productRepository.Update(category);
		}
	}
}
