using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MY_MVCProjeKampi.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager contentManager = new ContentManager(new EfContentDal());
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllContent(string p)
        {
            List<Content> values = new List<Content>();
            if (string.IsNullOrEmpty(p))
            {
                values = contentManager.GetAll();
                
            }
            else
            {
                values = contentManager.GetBySearch(p);
            }
            

            //var values = c.Contents.ToList();
            return View(values);
        }

        public ActionResult ContentByHeading(int id)
        {
            var contentValues = contentManager.GetAllByHeadingId(id);
            return View(contentValues);
        }
    }
}