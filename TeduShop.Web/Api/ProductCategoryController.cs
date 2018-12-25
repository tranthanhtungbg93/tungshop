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
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpRes(request, () =>
            {
                var model = _productCategoryService.GetAll();
                var requestData = Mapper.Map<List<ProductCategoryModel>>(model);
                var reponse = request.CreateResponse(HttpStatusCode.OK, requestData);
                return reponse;
            });
        }
    }
}
