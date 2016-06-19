using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        ProductService.ProductServiceClient client = new ProductService.ProductServiceClient();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetAllProducts()
        {            
            var products = client.GetAllProducts();
            return Json(products, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetProduct(int id)
        {            
            var product = client.GetProduct(id);
            return Json(product, JsonRequestBehavior.AllowGet);
        }


    
    }
}