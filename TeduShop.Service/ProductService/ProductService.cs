﻿using System;
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

		public IEnumerable<Product> GetListProductByCategoryIdPaging(int categoryId, int page, int pageSize, out int totalRow, string sort)
		{
			var query = _productRepository.GetMulti(x => x.Status && x.CateforyID == categoryId);

			switch (sort)
			{
				case "popular":
					query = query.OrderByDescending(x => x.ViewCount);
					break;
				case "discount":
					query = query.OrderByDescending(x => x.PromotionPrice.HasValue);
					break;
				case "price":
					query = query.OrderBy(x => x.Price);
					break;
				default:
					query = query.OrderByDescending(x => x.CreatedDate); // mac dinh sap xep theo dk nay
					break;
			}

			totalRow = query.Count();
			return query.OrderBy(x => x.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize).ToList();
		}

		public IEnumerable<Product> GetListProductbyTag(string tagId, int page, int pageSize, out int totalRow)
		{
			var model = _productRepository.GetListProductByTag(tagId, page, pageSize,out totalRow);

			return model;
		}

		public IEnumerable<string> GetListProuductByName(string Keyword)
		{
			return _productRepository.GetMulti(x => x.Status && x.Name.Contains(Keyword)).Select(y => y.Name);
		}

		public IEnumerable<Tag> GetListTagByProductId(int id)
		{
			return _productTagRespository.GetMulti(x => x.ProductID == id, new string[] { "Tag" }).Select(y => y.Tag);
		}

		public IEnumerable<Product> GetSanPhamLienQuan(int id, int top)
		{
			var product = _productRepository.GetSingleById(id);

			return _productRepository.GetMulti(x => x.Status && x.ID != id && x.CateforyID == product.CateforyID)
					.OrderByDescending(x => x.CreatedDate)
					.Take(top);
		}

		public Tag GetTag(string tagId)
		{
			return _tagRepository.GetSingleByCondition(x => x.ID == tagId);
		}

		public void IncreaseView(int id)
		{
			var product = _productRepository.GetSingleById(id);
			if (product.ViewCount.HasValue)
			{
				product.ViewCount += 1;
			}
			else
			{
				product.ViewCount = 1;
			}
		}

		public void SaveChange()
		{
			_unitOfWork.Commit();
		}

		public IEnumerable<Product> Search(string keyword, int page, int pageSize, out int totalRow, string sort)
		{
			var query = _productRepository.GetMulti(x => x.Status && x.Name.Contains(keyword));

			switch (sort)
			{
				case "popular":
					query = query.OrderByDescending(x => x.ViewCount);
					break;
				case "discount":
					query = query.OrderByDescending(x => x.PromotionPrice.HasValue);
					break;
				case "price":
					query = query.OrderBy(x => x.Price);
					break;
				default:
					query = query.OrderByDescending(x => x.CreatedDate); // mac dinh sap xep theo dk nay
					break;
			}

			totalRow = query.Count();
			return query.OrderBy(x => x.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize).ToList();
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
