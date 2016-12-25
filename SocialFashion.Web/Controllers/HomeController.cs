using Microsoft.AspNet.Identity;
using SocialFashion.Model.Models;
using SocialFashion.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialFashion.Web.Controllers
{
    public class HomeController : Controller
    {
        SocialFashionDbContext db;
        public HomeController(IProductService productServicer)
        {
            db = new SocialFashionDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Chat()
        {
            return PartialView();
        }

        public ActionResult ToolbarDesktopPartial()
        {
            return PartialView();
        }

        public JsonResult GetNotificationAPI()
        {

            var currentUserId = User.Identity.GetUserId();
            using (SocialFashionDbContext db = new SocialFashionDbContext())
            {
                List<Notifications_GetNotiByRecieverId_Result> result = db.Notifications_GetNotiByRecieverId(currentUserId).ToList();
                return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        public JsonResult GetCountNotificationAPI()
        {

            var currentUserId = User.Identity.GetUserId();
            using (SocialFashionDbContext db = new SocialFashionDbContext())
            {
                int? result = db.Notifications_GetCountNotiByRecieverId(currentUserId).FirstOrDefault();
                return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        public JsonResult GetMessageAPI()
        {
            var currentUserMail = User.Identity.GetUserName();
            using (SocialFashionDbContext db = new SocialFashionDbContext())
            {
                List<Messages_GetLastMessageByRecieverEmail_Result> result = db.Messages_GetLastMessageByRecieverEmail(currentUserMail).ToList();
                return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

           
        }

        public JsonResult GetCountMessageAPI()
        {

            var currentUserMail = User.Identity.GetUserName();
            using (SocialFashionDbContext db = new SocialFashionDbContext())
            {
                int? result = db.Messages_GetCountByRecieverEmail(currentUserMail).FirstOrDefault();
                return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        public JsonResult GetFanAPI()
        {
            var currentUserId = User.Identity.GetUserId();
            using (SocialFashionDbContext db = new SocialFashionDbContext())
            {
                List<Fans_GetFanByRequestId_Result>  result = db.Fans_GetFanByRequestId(currentUserId).ToList();
                return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }


        }

        public JsonResult GetCountFanAPI()
        {
            var currentUserId = User.Identity.GetUserId();
            using (SocialFashionDbContext db = new SocialFashionDbContext())
            {
                int? result = db.Fans_GetCountFanByRequestId(currentUserId).FirstOrDefault();
                return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
    }
}