using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MY_MVCProjeKampi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult Headings()
        {
            var headingList = headingManager.GetAll();
            return View(headingList);
        }
        public PartialViewResult Index(int id=0)
        {
            var contentList = contentManager.GetAllByHeadingId(id);
            return PartialView(contentList);
        }
    }
}