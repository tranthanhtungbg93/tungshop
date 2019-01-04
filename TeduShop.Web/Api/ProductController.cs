using AutoMapper;
using System;
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
	[RoutePrefix("api/product")]
	public class ProductController : ApiControllerBase
	{
		IProductService _productService;

		public ProductController(ILogError errorService, IProductService productService) : base(errorService)
		{
			_productService = productService;
		}

		[Route("loadListDanhMuc")]
		[HttpGet]
		public HttpResponseMessage GetAll(HttpRequestMessage request)
		{
			return CreateHttpRes(request, () =>
			{
				var model = _productService.GetAll();

				var requestData = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductModel>>(model);

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
				var model = _productService.GetById(id);

				var requestData = Mapper.Map<Product, ProductModel>(model);

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
				var model = _productService.GetAll(keyword);

				totalRow = model.Count();
				var query = model.OrderByDescending(x => x.CreatedDate).Skip((page - 1) * pageOfSize).Take(pageOfSize);

				var requestData = Mapper.Map<List<ProductModel>>(query);

				var paginationSet = new PaginationSet<ProductModel>()
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
		public HttpResponseMessage Create(HttpRequestMessage request, ProductModel model)
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
					Product product = new Product();
					product.AddProduct(model);

					var result = _productService.Add(product);
					_productService.SaveChange();

					res = request.CreateResponse(HttpStatusCode.Created, result);
				}
				return res;
			});
		}

		[Route("update")]
		[HttpPut]
		[AllowAnonymous]
		public HttpResponseMessage Update(HttpRequestMessage request, ProductModel model)
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
					var newProduct = _productService.GetById(model.ID);
					newProduct.UpdateProduct(model);

					_productService.Update(newProduct);
					_productService.SaveChange();

					var reponseData = Mapper.Map<Product, ProductModel>(newProduct);

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
					var oldProduct = _productService.Delete(id);

					_productService.SaveChange();

					var reponseData = Mapper.Map<Product, ProductModel>(oldProduct);

					res = request.CreateResponse(HttpStatusCode.OK, reponseData);
				}
				return res;
			});
		}
		[Route("deleteMulti")]
		[HttpDelete]
		[AllowAnonymous]
		public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedProducts)
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
					var listProduct = new JavaScriptSerializer().Deserialize<List<int>>(checkedProducts);

					foreach (var item in listProduct)
					{
						_productService.Delete(item);
					}

					_productService.SaveChange();

					res = request.CreateResponse(HttpStatusCode.OK, listProduct.Count);
				}
				return res;
			});
		}
	}
}
