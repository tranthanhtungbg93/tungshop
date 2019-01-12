using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
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
			var productModel = _productService.GetById(id);
			var viewModel = Mapper.Map<Product, ProductModel>(productModel);

			var relatedProduct = _productService.GetSanPhamLienQuan(id, 6);

			ViewBag.RelatedProducts = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductModel>>(relatedProduct);

			List<string> lstImg = new JavaScriptSerializer().Deserialize<List<string>>(viewModel.MoreImages);

			ViewBag.MoreImgs = lstImg;

			return View(viewModel);
		}

		public ActionResult Category(int id, int page = 1, string sort = "")
		{
			int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
			int totalRow = 0;
			var producModel = _productService.GetListProductByCategoryIdPaging(id, page, pageSize, out totalRow, sort);
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

		public JsonResult GetListProductByName(string KeyWord)
		{
			var model = _productService.GetListProuductByName(KeyWord);
			return Json(new
			{
				data = model
			}, JsonRequestBehavior.AllowGet);
		}
		public ActionResult Search(string keyword, int page = 1, string sort = "")
		{
			int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
			int totalRow = 0;
			var producModel = _productService.Search(keyword, page, pageSize, out totalRow, sort);
			var prductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductModel>>(producModel);

			var totalPage = (int)Math.Ceiling((double)totalRow / pageSize);

			ViewBag.Keyword = keyword;
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