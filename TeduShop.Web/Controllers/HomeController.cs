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
		IProductService _productService;
		public HomeController(IProductCategoryService productCategoryService,
							ICommonService commonService,
							IProductService productService)
		{
			_productCategoryService = productCategoryService;
			_commonService = commonService;
			_productService = productService;
		}
		[OutputCache(Duration =60,Location =System.Web.UI.OutputCacheLocation.Server)]
		public ActionResult Index()
		{
			var slideModel = _commonService.GetSlides();
			var sildeVM = Mapper.Map<IEnumerable<Slide>, IEnumerable<SlideModel>>(slideModel);
			var homeVM = new HomeViewModel();
			homeVM.Slides = sildeVM;

			var lastestProduct = _productService.GetLastest(3);
			var lastestProductVM = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductModel>>(lastestProduct);
			var topSale = _productService.GetHotProduct(3);
			var ltopSaleVM = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductModel>>(topSale);

			homeVM.TopSaleProducts = ltopSaleVM;
			homeVM.LastestProducts = lastestProductVM;
			return View(homeVM);
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
		[OutputCache(Duration = 36000)]
		public ActionResult Footer()
		{
			var footerModel = _commonService.GetFooter();
			var footerVM = Mapper.Map<Footer, FooterModel>(footerModel);
			ViewBag.Time = DateTime.Now.ToString("T");
			return PartialView(footerVM);
		}

		[ChildActionOnly] // chỉ cho phép đọc
		public ActionResult Header()
		{
			return PartialView();
		}

		[ChildActionOnly] // chỉ cho phép đọc
		[OutputCache(Duration = 36000)]
		public ActionResult MenuCategory()
		{
			var model = _productCategoryService.GetAll();
			var listProductCategoryVM = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryModel>>(model);
			return PartialView(listProductCategoryVM);
		}
	}
}