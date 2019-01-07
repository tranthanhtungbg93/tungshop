using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using TeduShop.Model.Model;
using TeduShop.Service.Error;
using TeduShop.Service.ProductCategoryService;
using TeduShop.Web.Infrastructure.Core;
using TeduShop.Web.Infrastructure.Extenssion;
using TeduShop.Web.Models;

namespace TeduShop.Web.Api
{
	[RoutePrefix("api/productCategory")]
	[Authorize]
	public class ProductCategoryController : ApiControllerBase
	{
		IProductCategoryService _productCategoryService;

		public ProductCategoryController(ILogError errorService, IProductCategoryService productCategoryService) : base(errorService)
		{
			_productCategoryService = productCategoryService;
		}

		[Route("loadListDanhMuc")]
		[HttpGet]
		public HttpResponseMessage GetAll(HttpRequestMessage request)
		{
			return CreateHttpRes(request, () =>
			{
				var model = _productCategoryService.GetAll();

				var requestData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryModel>>(model);

				var reponse = request.CreateResponse(HttpStatusCode.OK, requestData);
				return reponse;
			});
		}

		[Route("getbyid/{id:int}")]
		[HttpGet]
		public HttpResponseMessage GetById(HttpRequestMessage request, int id)
		{
			return CreateHttpRes(request, () =>
			{
				var model = _productCategoryService.GetById(id);

				var requestData = Mapper.Map<ProductCategory, ProductCategoryModel>(model);

				var reponse = request.CreateResponse(HttpStatusCode.OK, requestData);

				return reponse;
			});
		}

		[Route("getList")]
		[HttpGet]
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

		[Route("create")]
		[HttpPost]
		[AllowAnonymous]
		public HttpResponseMessage Create(HttpRequestMessage request, ProductCategoryModel model)
		{
			return CreateHttpRes(request, () =>
			{
				HttpResponseMessage res = null;
				if (!ModelState.IsValid)
				{
					request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
				}
				else
				{
					ProductCategory productCategory = new ProductCategory();
					productCategory.CreatedBy = User.Identity.Name;
					productCategory.AddProductCategory(model);

					var result = _productCategoryService.Add(productCategory);
					_productCategoryService.SaveChange();

					res = request.CreateResponse(HttpStatusCode.Created, result);
				}
				return res;
			});
		}

		[Route("update")]
		[HttpPut]
		[AllowAnonymous]
		public HttpResponseMessage Update(HttpRequestMessage request, ProductCategoryModel model)
		{
			return CreateHttpRes(request, () =>
			{
				HttpResponseMessage res = null;
				if (!ModelState.IsValid)
				{
					res = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
				}
				else
				{
					var newProductCategory = _productCategoryService.GetById(model.ID);
					newProductCategory.UpdatedBy = User.Identity.Name;
					newProductCategory.UpdateProductCategory(model);

					_productCategoryService.Update(newProductCategory);
					_productCategoryService.SaveChange();

					var reponseData = Mapper.Map<ProductCategory, ProductCategoryModel>(newProductCategory);

					res = request.CreateResponse(HttpStatusCode.OK, reponseData);
				}
				return res;
			});
		}

		[Route("delete")]
		[HttpDelete]
		[AllowAnonymous]
		public HttpResponseMessage Delete(HttpRequestMessage request, int id)
		{
			return CreateHttpRes(request, () =>
			{
				HttpResponseMessage res = null;
				if (!ModelState.IsValid)
				{
					res = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
				}
				else
				{
					var oldProductCategory = _productCategoryService.Delete(id);

					_productCategoryService.SaveChange();

					var reponseData = Mapper.Map<ProductCategory, ProductCategoryModel>(oldProductCategory);

					res = request.CreateResponse(HttpStatusCode.OK, reponseData);
				}
				return res;
			});
		}
		[Route("deleteMulti")]
		[HttpDelete]
		[AllowAnonymous]
		public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedProductCategories)
		{
			return CreateHttpRes(request, () =>
			{
				HttpResponseMessage res = null;
				if (!ModelState.IsValid)
				{
					res = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
				}
				else
				{
					var listProductCategory = new JavaScriptSerializer().Deserialize<List<int>>(checkedProductCategories);

					foreach (var item in listProductCategory)
					{
						_productCategoryService.Delete(item);
					}

					_productCategoryService.SaveChange();

					res = request.CreateResponse(HttpStatusCode.OK, listProductCategory.Count);
				}
				return res;
			});
		}
	}
}
