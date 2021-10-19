using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MY_MVCProjeKampi.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var aboutValues = aboutManager.GetAll();
            return View(aboutValues);
        }
        [HttpPost]
        public ActionResult AddAbout(About entity)
        {
            aboutManager.Add(entity);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}