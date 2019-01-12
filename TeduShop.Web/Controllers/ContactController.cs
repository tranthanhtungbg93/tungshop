using AutoMapper;
using System.Web.Mvc;
using TeduShop.Model.Model;
using TeduShop.Service;
using TeduShop.Web.Models;

namespace TeduShop.Web.Controllers
{
    public class ContactController : Controller
    {
		IContactDetailService _contactDetailService;
		public ContactController(IContactDetailService contactDetailService)
		{
			_contactDetailService = contactDetailService;
		}
		// GET: Contact
		public ActionResult Index()
        {
			var model = Mapper.Map<ThongTinLienLac, ThongTinLienLacModel>(_contactDetailService.GetDefaultContact());
            return View(model);
        }
    }
}