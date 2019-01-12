using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeduShop.Model.Model;
using TeduShop.Service;
using TeduShop.Web.Models;

namespace TeduShop.Web.Controllers
{
	public class PageController : Controller
	{
		IPageService _pageService;
		public PageController(IPageService pageService)
		{
			_pageService = pageService;
		}
		// GET: Page
		public ActionResult Index(string alias)
		{
			var page = _pageService.GetbyAlias(alias);
			var modelMapper = Mapper.Map<Page, PageModel>(page);
			return View(modelMapper);
		}
	}
}