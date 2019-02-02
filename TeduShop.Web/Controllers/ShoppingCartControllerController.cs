using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TeduShop.Common;
using TeduShop.Model.Model;
using TeduShop.Service.ProductCategoryService;
using TeduShop.Web.Models;

namespace TeduShop.Web.Controllers
{
    public class ShoppingCartControllerController : Controller
    {
        IProductService _productService;

        public ShoppingCartControllerController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: ShoppingCartController
        public ActionResult Index()
        {
            Session[CommonConstant.SessionCart] = new List<ShoppingCartModel>();
            return View();
        }

        public JsonResult GetAll()
        {
            var cart = (List<ShoppingCartModel>)Session[CommonConstant.SessionCart];
            return Json(new
            {
                data = cart
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(int productId)
        {
            var cart = (List<ShoppingCartModel>)Session[CommonConstant.SessionCart];
            if (cart.Any(x => x.ProductId == productId))
            {
                foreach (var item in cart)
                {
                    if (item.ProductId == productId)
                    {
                        item.Quantity += 1;
                    }

                }
            }
            else
            {
                ShoppingCartModel newItem = new ShoppingCartModel();
                newItem.ProductId = productId;
                var product = _productService.GetById(productId);
                newItem.Product = Mapper.Map<Product, ProductModel>(product);
                newItem.Quantity = 1;
            }

            Session[CommonConstant.SessionCart] = cart;
            return Json(new
            {
                status = true
            });
        }
        [HttpPost]
        public JsonResult UpdateGioHang(string cartData)
        {
            var cartModel = new JavaScriptSerializer().Deserialize<List<ShoppingCartModel>>(cartData);
            var cartSession = (List<ShoppingCartModel>)Session[CommonConstant.SessionCart];
            foreach (var item in cartSession)
            {
                foreach (var jitem in cartModel)
                {
                    if (item.ProductId == jitem.ProductId)
                    {
                        // cap nhat so luong
                        item.Quantity = jitem.Quantity;
                    }
                }
            }

            Session[CommonConstant.SessionCart] = cartSession;
            return Json(new
            {
                status = true
            });
        }

        [HttpPost]
        public JsonResult DeleteAll()
        {
            Session[CommonConstant.SessionCart] = new List<ShoppingCartModel>();
            return Json(new
            {
                status = true
            });
        }
    }
}