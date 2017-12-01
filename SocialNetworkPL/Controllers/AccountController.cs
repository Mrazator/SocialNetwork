using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.Facades;
using SocialNetworkPL.Models;

namespace SocialNetworkPL.Controllers
{
    public class AccountController : Controller
    {
        public UserFacade UserFacade { get; set; }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(UserCreateDto userCreateDto)
        {
            try
            {
                await UserFacade.RegisterUser(userCreateDto);

                var authTicket = new FormsAuthenticationTicket(1, userCreateDto.NickName, DateTime.Now,
                    DateTime.Now.AddMinutes(30), false, "");
                var encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);

                return RedirectToAction("Index", "Home");
            }
            catch (ArgumentException)
            {
                ModelState.AddModelError("Username", "Account with that username already exists!");
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            if (string.IsNullOrWhiteSpace(model.NickName) || string.IsNullOrWhiteSpace(model.Password))
            {
                ModelState.AddModelError("", "Wrong username or password!");
                return View();
            }

            var success = await UserFacade.Login(model.NickName, model.Password);
            if (success)
            {
                //FormsAuthentication.SetAuthCookie(model.Username, false);

                var authTicket = new FormsAuthenticationTicket(1, model.NickName, DateTime.Now,
                    DateTime.Now.AddMinutes(30), false, "");
                var encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);

                var decodedUrl = "";
                if (!string.IsNullOrEmpty(returnUrl))
                    decodedUrl = Server.UrlDecode(returnUrl);

                if (Url.IsLocalUrl(decodedUrl))
                    return Redirect(decodedUrl);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Wrong username or password!");
            return View();
        }

        public async Task<ActionResult> Logout()
        {
            await UserFacade.GetUserByNickNameAsync(User.Identity.Name);
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}