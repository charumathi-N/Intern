using Intern.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Http;

namespace Intern.Controllers
{
    public class LoginController : Controller
    {
        private readonly InternContext context;

        public LoginController(InternContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginDetail loginDetail)
        {
            var myUser = context.LoginDetails.Where(x => x.EmailId == loginDetail.EmailId && x.Password == loginDetail.Password).FirstOrDefault();
            if (myUser != null)
            {
                HttpContext.Session.SetString("UserSession", myUser.EmailId);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Login Failed..";
            }
            return View();
        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                HttpContext.Session.Remove("UserSession");
                return RedirectToAction("Login");
            }
            return View();
            
        }
    }
}
