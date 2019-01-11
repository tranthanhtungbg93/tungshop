using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Common;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Reponsitories;
using TeduShop.Model.Model;

namespace TeduShop.Service.ProductCategoryService
{
	public class ProductService : IProductService
	{
		IUnitOfWork _unitOfWork;
		IProductRepository _productRepository;
		ITagRepository _tagRepository;
		IProductTagRepository _productTagRespository;

		public ProductService(IProductTagRepository productTagRespository, ITagRepository tagRepository, IProductRepository productRepository, IUnitOfWork unitOfWork)
		{
			_productRepository = productRepository;
			_unitOfWork = unitOfWork;
			_tagRepository = tagRepository;
			_productTagRespository = productTagRespository;
		}

		public Product Add(Product product)
		{
			var result = _productRepository.Add(product);
			_unitOfWork.Commit();
			if (!string.IsNullOrEmpty(product.Tags))
			{
				string[] tags = product.Tags.Split(',');
				for (var i = 0; i < tags.Length; i++)
				{
					var tagId = StringHelper.ToUnsignString(tags[i]);
					if (_tagRepository.Count(x => x.ID == tagId) == 0)
					{
						Tag tag = new Tag();
						tag.ID = tagId;
						tag.Name = tags[i];
						tag.Type = CommonConstant.ProductTag;
						_tagRepository.Add(tag);
						_unitOfWork.Commit();
					}

					ProductTag productTag = new ProductTag();
					productTag.ProductID = product.ID;
					productTag.TagID = tagId;
					_productTagRespository.Add(productTag);
				}
			}
			return result;
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

		public IEnumerable<Product> GetHotProduct(int id)
		{
			return _productRepository.GetMulti(x => x.Status && x.HotFlag == true).OrderByDescending(x => x.CreatedDate).Take(id);
		}

		public IEnumerable<Product> GetLastest(int id)
		{
			return _productRepository.GetMulti(x => x.Status).OrderByDescending(x => x.CreatedDate).Take(id);
		}

		public IEnumerable<Product> GetListProductByCategoryIdPaging(int categoryId, int page, int pageSize, out int totalRow)
		{
			var query = _productRepository.GetMulti(x => x.Status && x.CateforyID == categoryId);
			totalRow = query.Count();
			return query.OrderBy(x => x.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize).ToList();
		}

		public void SaveChange()
		{
			_unitOfWork.Commit();
		}

		public void Update(Product product)
		{
			_productRepository.Update(product);
			if (!string.IsNullOrEmpty(product.Tags))
			{
				string[] tags = product.Tags.Split(',');
				for (var i = 0; i < tags.Length; i++)
				{
					var tagId = StringHelper.ToUnsignString(tags[i]);
					if (_tagRepository.Count(x => x.ID == tagId) == 0)
					{
						Tag tag = new Tag();
						tag.ID = tagId;
						tag.Name = tags[i];
						tag.Type = CommonConstant.ProductTag;
						_tagRepository.Add(tag);
						_unitOfWork.Commit();
					}
					_productTagRespository.DeleteMulti(x => x.ProductID == product.ID);
					ProductTag productTag = new ProductTag();
					productTag.ProductID = product.ID;
					productTag.TagID = tagId;
					_productTagRespository.Add(productTag);
				}

			}
			_unitOfWork.Commit();
		}
	}
}
