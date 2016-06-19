using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DataLayer.Entities;



namespace WebUI.Controllers
{
    public class AdminController : Controller
    {
        //CRUD controller
        ProductService.ProductServiceClient client = new ProductService.ProductServiceClient();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllProducts()
        {
            return Json(client.GetAllProducts(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EditProduct(Product item)
        {
            item = client.SaveProduct(item);
            return Json(item, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public JsonResult DeleteProduct(int id)
        {
            var prod = client.DeleteProduct(id);
            return Json(prod, JsonRequestBehavior.AllowGet);           

        }
    }
}