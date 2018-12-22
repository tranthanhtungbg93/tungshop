using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeduShop.Model.Model;
using TeduShop.Service.Error;
using TeduShop.Service.PostCategoryService;
using TeduShop.Web.Infrastructure.Core;

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

        public HttpResponseMessage Post(HttpRequestMessage req, PostCategory postCategory)
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
                    var result = _postCategoryService.Add(postCategory);
                    _postCategoryService.SaveChange();

                    res = req.CreateResponse(HttpStatusCode.Created, result);
                }
                return res;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage req, PostCategory postCategory)
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
                    _postCategoryService.Update(postCategory);
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
                if (ModelState.IsValid)
                {
                    req.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var listCategory = _postCategoryService.GetAll();

                    res = req.CreateResponse(HttpStatusCode.OK, listCategory);
                }
                return res;
            });
        }

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
