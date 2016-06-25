using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
namespace WebUI.Controllers
{
    //userName = admin, password = 12345
    public class AccountController : Controller
    {
        IAuthProvider authProvider = new FormsAuthProvider(); //по-хорошему нужно было использовать DI
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.UserName, model.Password))
                {
                    return (Redirect(returnUrl ?? Url.RouteUrl(new {controller = "admin", action="Index" })));
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            else
            {
                return View();
            }
            
        }
    }
}