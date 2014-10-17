using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using GuestBookZhKassenov.Models;

namespace GuestBookZhKassenov.Controllers
{
    public class FeedbackController : Controller
    {
        private GuestBookContext db = new GuestBookContext();

        public ActionResult Index(string sortOrder, int? page)
        {
            ViewBag.CurrentSort = sortOrder;

            ViewBag.SystimeSort = String.IsNullOrEmpty(sortOrder) ? "date_asc" : "";
            ViewBag.NameSort = sortOrder == "Name" ? "name_desc" : "Name";
            ViewBag.EmailSort = sortOrder == "Email" ? "email_desc" : "Email";
            
            var feedbacks = from f in db.Feedbacks select f;

            switch (sortOrder)
            {
                case "date_asc":
                    feedbacks = feedbacks.OrderBy(s => s.systime);
                    break;
                case "name_desc":
                    feedbacks = feedbacks.OrderByDescending(s => s.username);
                    break;
                case "Name":
                    feedbacks = feedbacks.OrderBy(s => s.username);
                    break;
                case "email_desc":
                    feedbacks = feedbacks.OrderByDescending(s => s.email);
                    break;
                case "Email":
                    feedbacks = feedbacks.OrderBy(s => s.email);
                    break;
                default:
                    feedbacks = feedbacks.OrderByDescending(s => s.systime);
                    break;
            }

            int pageSize = 25;
            int pageNumber = (page ?? 1);
            return View(feedbacks.ToPagedList(pageNumber, pageSize));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
