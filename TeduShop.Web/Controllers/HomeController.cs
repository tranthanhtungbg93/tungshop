using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeduShop.Model.Model;
using TeduShop.Service;
using TeduShop.Service.ProductCategoryService;
using TeduShop.Web.Models;

namespace TeduShop.Web.Controllers
{
	public class HomeController : Controller
	{
		IProductCategoryService _productCategoryService;
		ICommonService _commonService;
		public HomeController(IProductCategoryService productCategoryService, ICommonService commonService)
		{
			_productCategoryService = productCategoryService;
			_commonService = commonService;
		}

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		[ChildActionOnly]
		public ActionResult Footer()
		{
			var footerModel = _commonService.GetFooter();
			var footerVM = Mapper.Map<Footer, FooterModel>(footerModel);
			return PartialView(footerVM);
		}

		[ChildActionOnly] // chỉ cho phép đọc
		public ActionResult Header()
		{
			return PartialView();
		}

		[ChildActionOnly] // chỉ cho phép đọc
		public ActionResult MenuCategory()
		{
			var model = _productCategoryService.GetAll();
			var listProductCategoryVM = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryModel>>(model);
			return PartialView(listProductCategoryVM);
		}
	}
}