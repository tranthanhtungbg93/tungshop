using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeduShop.Common;
using TeduShop.Model.Model;
using TeduShop.Service.ProductCategoryService;
using TeduShop.Web.Infrastructure.Core;
using TeduShop.Web.Models;

namespace TeduShop.Web.Controllers
{
	public class ProductController : Controller
	{
		IProductService _productService;
		IProductCategoryService _productCategoryService;
		public ProductController(IProductService productService, IProductCategoryService productCategoryService)
		{
			_productService = productService;
			_productCategoryService = productCategoryService;
		}
		// GET: Product
		public ActionResult Detail(int id)
		{

			return View();
		}

		public ActionResult Category(int id, int page = 1)
		{
			int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
			int totalRow = 0;
			var producModel = _productService.GetListProductByCategoryIdPaging(id, page, pageSize, out totalRow);
			var prductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductModel>>(producModel);

			var totalPage = (int)Math.Ceiling((double)totalRow / pageSize);

			var category = _productCategoryService.GetById(id);
			ViewBag.Category = Mapper.Map<ProductCategory, ProductCategoryModel>(category);
			var paginationSet = new PaginationSet<ProductModel>()
			{
				Items = prductViewModel,
				MaxPage = int.Parse(ConfigHelper.GetByKey("MaxPage")),
				Page = page,
				TotalCount = totalRow,
				TotalPage = totalPage
			};
			return View(paginationSet);
		}
	}
}