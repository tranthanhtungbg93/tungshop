using AutoMapper;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeduShop.Model.Model;
using TeduShop.Service.Error;
using TeduShop.Service.PostCategoryService;
using TeduShop.Web.Infrastructure.Core;
using TeduShop.Web.Infrastructure.Extenssion;
using TeduShop.Web.Models;

namespace TeduShop.Web.Api
{
    [RoutePrefix("api/postCategory")]
    public class PostCategoryController : ApiControllerBase
    {
        IPostCategoryService _postCategoryService;
        public PostCategoryController(ILogError logError, IPostCategoryService postCategoryService) : base(logError)
        {
            _postCategoryService = postCategoryService;
        }
        [Route("post")]
        public HttpResponseMessage Post(HttpRequestMessage req, PostCategoryModel model)
        {
            return CreateHttpRes(req, () =>
            {
                HttpResponseMessage res = null;
                if (!ModelState.IsValid)
                {
                    req.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    PostCategory postCategory = new PostCategory();
                    postCategory.UpdateCategory(model);

                    var result = _postCategoryService.Add(postCategory);
                    _postCategoryService.SaveChange();

                    res = req.CreateResponse(HttpStatusCode.Created, result);
                }
                return res;
            });
        }
        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage req, PostCategoryModel model)
        {
            return CreateHttpRes(req, () =>
            {
                HttpResponseMessage res = null;
                if (ModelState.IsValid)
                {
                    req.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var postCategoryDB = _postCategoryService.GetById(model.ID);

                    postCategoryDB.UpdateCategory(model);

                    _postCategoryService.Update(postCategoryDB);

                    _postCategoryService.SaveChange();

                    res = req.CreateResponse(HttpStatusCode.OK);
                }
                return res;
            });
        }
        [Route("GetAll")]
        public HttpResponseMessage Get(HttpRequestMessage req)
        {
            return CreateHttpRes(req, () =>
            {
                HttpResponseMessage res = null;

                var listCategory = _postCategoryService.GetAll();

                var listCategoryModel = Mapper.Map<List<PostCategoryModel>>(listCategory);

                res = req.CreateResponse(HttpStatusCode.OK, listCategoryModel);
                return res;
            });
        }
        [Route("delete")]
        public HttpResponseMessage Delete(HttpRequestMessage req, int id)
        {
            return CreateHttpRes(req, () =>
            {
                HttpResponseMessage res = null;
                if (ModelState.IsValid)
                {
                    req.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _postCategoryService.Delete(id);
                    _postCategoryService.SaveChange();

                    res = req.CreateResponse(HttpStatusCode.OK);
                }
                return res;
            });
        }
    }
}
