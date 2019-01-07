using System.Web.Http;
using TeduShop.Service.Error;
using TeduShop.Web.Infrastructure.Core;

namespace TeduShop.Web.Api
{
	[RoutePrefix("api/home")]
	[Authorize]
	public class HomeController : ApiControllerBase
	{
		ILogError _error;
		public HomeController(ILogError error) : base(error)
		{
			_error = error;
		}

		[HttpGet]
		[Route("TestMethod")]
		public string TestMethod()
		{
			return "Hello, TRan thanh tung";
		}
	}
}
