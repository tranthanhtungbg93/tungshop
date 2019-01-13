using AutoMapper;
using BotDetect.Web.Mvc;
using System.Web.Mvc;
using TeduShop.Common;
using TeduShop.Model.Model;
using TeduShop.Service;
using TeduShop.Web.Infrastructure.Extenssion;
using TeduShop.Web.Models;

namespace TeduShop.Web.Controllers
{
	public class ContactController : Controller
	{
		IContactDetailService _contactDetailService;
		IFeedbackService _feedbackService;
		public ContactController(IContactDetailService contactDetailService, IFeedbackService feedbackService)
		{
			_contactDetailService = contactDetailService;
			_feedbackService = feedbackService;
		}
		// GET: Contact
		public ActionResult Index()
		{
			FeedbackModel feedbackModel = new FeedbackModel();
			feedbackModel.ThongTinLienLacModel = GetDetail();
			return View(feedbackModel);
		}
		[HttpPost]
		[CaptchaValidation("CaptchaCode", "contactCaptcha", "Mã xác nhận không đúng")]
		public ActionResult SendResult(FeedbackModel feedbackModel)
		{
			if (ModelState.IsValid)
			{
				Feedback feedback = new Feedback();
				feedback.UpdateFeedBack(feedbackModel);
				_feedbackService.Create(feedback);
				_feedbackService.Save();

				ViewData["SuccessMsg"] = "Gửi phản hồi thành công.";

				string content = System.IO.File.ReadAllText(Server.MapPath("/Assets/Client/template/contact_template.html"));
				content = content.Replace("{{Name}}", feedbackModel.Name);
				content = content.Replace("{{Email}}", feedbackModel.Email);
				content = content.Replace("{{Message}}", feedbackModel.Message);
				var adminEmail = ConfigHelper.GetByKey("AdminEmail");
				MailHelper.SendMail(adminEmail, "Thông tin liên hệ từ website", content);


				feedbackModel.Name = "";
				feedbackModel.Message = "";
				feedbackModel.Email = "";
			}
			feedbackModel.ThongTinLienLacModel = GetDetail();

			return View("Index", feedbackModel);
		}

		private ThongTinLienLacModel GetDetail()
		{
			var model = Mapper.Map<ThongTinLienLac, ThongTinLienLacModel>(_contactDetailService.GetDefaultContact());
			return model;
		}
	}
}