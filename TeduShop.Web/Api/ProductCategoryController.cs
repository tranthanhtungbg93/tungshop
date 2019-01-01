using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeduShop.Model.Model;
using TeduShop.Service.Error;
using TeduShop.Service.ProductService;
using TeduShop.Web.Infrastructure.Core;
using TeduShop.Web.Models;

namespace TeduShop.Web.Api
{
	[RoutePrefix("api/productCategory")]
	public class ProductCategoryController : ApiControllerBase
	{
		IProductCategoryService _productCategoryService;

		public ProductCategoryController(ILogError errorService, IProductCategoryService productCategoryService) : base(errorService)
		{
			_productCategoryService = productCategoryService;
		}

		[Route("getList")]
		public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageOfSize)
		{
			return CreateHttpRes(request, () =>
			{
				int totalRow = 0;
				var model = _productCategoryService.GetAll(keyword);

				totalRow = model.Count();
				var query = model.OrderByDescending(x => x.CreatedDate).Skip((page - 1) * pageOfSize).Take(pageOfSize);

				var requestData = Mapper.Map<List<ProductCategoryModel>>(query);

				var paginationSet = new PaginationSet<ProductCategoryModel>()
				{
					Items = requestData,
					Page = page,
					PageSize = pageOfSize,
					TotalCount = totalRow
				};

				var reponse = request.CreateResponse(HttpStatusCode.OK, paginationSet);
				return reponse;
			});
		}
	}
}
