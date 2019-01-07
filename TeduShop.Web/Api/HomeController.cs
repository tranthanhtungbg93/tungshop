using System.Web.Http;
using TeduShop.Service.Error;
using TeduShop.Web.Infrastructure.Core;

namespace TeduShop.Web.Api
{
	[RoutePrefix("api/home")]
	[Authorize]
	public class HomeController : ApiControllerBase
	{
		ILogError _errorService;
		public HomeController(ILogError errorService) : base(errorService)
		{
			this._errorService = errorService;
		}

		[HttpGet]
		[Route("TestMethod")]
		public string TestMethod()
		{
			return "Hello, TEDU Member. ";
		}
	}
}
