using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaptchaMvc;
using GuestBookZhKassenov.Models;
using System.Web.Security.AntiXss;

namespace GuestBookZhKassenov.Controllers
{
    public class GuestBookController : Controller
    {
        private GuestBookContext db = new GuestBookContext();

        [HttpGet]
        public ActionResult LeaveFeedback()
        {
            return View(new FeedbackViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [CaptchaMvc.Attributes.CaptchaVerify("Captcha is not valid")]
        public ActionResult LeaveFeedback(FeedbackViewModel data)
        {
            if (ModelState.IsValid)
            {
                Feedback feedback = new Feedback() { 
                    username = AntiXssEncoder.HtmlEncode(data.UserName, false), 
                    email = AntiXssEncoder.HtmlEncode(data.Email, false),
                    homepage = AntiXssEncoder.HtmlEncode(data.Homepage, false),
                    text = AntiXssEncoder.HtmlEncode(data.Text, false),
                    IP = Request.UserHostAddress,
                    browser = Request.Browser.Browser + " " + Request.Browser.MajorVersion,
                    systime = DateTime.Now
                };
                
                db.Feedbacks.Add(feedback);
                db.SaveChanges();
                
                ModelState.Clear();
                ViewBag.Sent = true;
                ViewBag.CaptchaError = "";

                return View(new FeedbackViewModel() { });
            }
            ViewBag.Sent = false;
            ViewBag.CaptchaError = "Ошибка: текст не соответствует изображению.";
            
            return View(data);
        }
    }
}
