using MY_MVCProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MY_MVCProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public List<modelCategory> BlogList()
        {
            List<modelCategory> ct = new List<modelCategory>();
            ct.Add(new modelCategory(){
                CategoryName = "Yazılım",
                CategoryCount= 8
            });
            ct.Add(new modelCategory()
            {
                CategoryName = "Seyahat",
                CategoryCount = 4
            });
            ct.Add(new modelCategory()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 8
            });
            ct.Add(new modelCategory()
            {
                CategoryName = "Spor",
                CategoryCount = 8
            });
            return ct;
        }
    }
}