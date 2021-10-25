using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MY_MVCProjeKampi.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test2()
        {
            return View();
        }

        public ActionResult ToDoList()
        {
            return View();
        }

        public ActionResult SweetAlert()
        {
            return View();
        }
    }
}