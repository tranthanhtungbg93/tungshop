﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Model.Model;

namespace TeduShop.Service.ProductCategoryService
{
	public interface IProductService
	{
		Product Add(Product category);
		void Update(Product category);
		Product Delete(int id);
		IEnumerable<Product> GetAll();
		IEnumerable<Product> GetAll(string keyword);
		IEnumerable<Product> GetAllbyCategoryID(int parentId);

		IEnumerable<Product> GetLastest(int id);
		IEnumerable<Product> GetHotProduct(int id);
		IEnumerable<Product> GetListProductByCategoryIdPaging(int categoryId, int page, int pageSize, out int totalRow, string sort);
		IEnumerable<Product> Search(string keyword, int page, int pageSize, out int totalRow, string sort);
		IEnumerable<string> GetListProuductByName(string Keyword);
		IEnumerable<Product> GetSanPhamLienQuan(int id, int top);
		Product GetById(int id);
		IEnumerable<Tag> GetListTagByProductId(int id);
		void IncreaseView(int id);
		IEnumerable<Product> GetListProductbyTag(string tagId, int page, int pageSize, out int totalRow);
		Tag GetTag(string tagId);
		void SaveChange();
	}
}
