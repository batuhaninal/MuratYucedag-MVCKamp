using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MY_MVCProjeKampi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        WriterLoginManager wlm = new WriterLoginManager(new EfWriterDal());
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin entity)
        {
            Context c = new Context();
            var adminUserInfo = c.Admins.FirstOrDefault(x => x.AdminUserName == entity.AdminUserName && x.AdminPassword == entity.AdminPassword);
            if (adminUserInfo!=null)
            {
                FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUserName, false);
                Session["AdminUserName"] = adminUserInfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer entity)
        {
            //Context c = new Context();
            //var writerUserInfo = c.Writers.FirstOrDefault(x => x.WriterMail == entity.WriterMail && x.WriterPassword == entity.WriterPassword);
            var writerUserInfo = wlm.GetWriter(entity.WriterMail, entity.WriterPassword);
            if (writerUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(writerUserInfo.WriterMail, false);
                Session["WriterMail"] = writerUserInfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
    }
}