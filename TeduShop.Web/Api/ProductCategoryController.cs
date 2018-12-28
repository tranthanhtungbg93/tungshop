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
        public HttpResponseMessage GetAll(HttpRequestMessage request, int page, int pageSize)
        {
            return CreateHttpRes(request, () =>
            {
                int totalRow = 0;
                var model = _productCategoryService.GetAll();

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);

                var requestData = Mapper.Map<List<ProductCategoryModel>>(query);

                var paginationSet = new PaginationSet<ProductCategoryModel>()
                {
                    Items = requestData,
                    Page = page,
                    TotalPage = (int)Math.Ceiling((decimal)totalRow / pageSize),
                    TotalCount = totalRow
                };

                var reponse = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return reponse;
            });
        }
    }
}
