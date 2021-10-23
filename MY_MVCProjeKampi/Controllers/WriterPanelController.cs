using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules.FluentValidation;

namespace MY_MVCProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        WriterValidator writerValidation = new WriterValidator();
        Context c = new Context();
        [HttpGet]
        public ActionResult WriterProfile(int id=0)
        {
            string p = (string)Session["WriterMail"];
            id = c.Writers.Where(x => x.WriterMail == p).Select(x => x.WriterId).FirstOrDefault();
            var writerValues = writerManager.GetById(id);
            return View(writerValues);
        }


        [HttpPost]
        public ActionResult WriterProfile(Writer entity)
        {
            ValidationResult result = writerValidation.Validate(entity);
            if (result.IsValid)
            {
                writerManager.Update(entity);
                return RedirectToAction("AllHeading");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult MyHeading(string p)
        {
            
            p = (string)Session["WriterMail"];
            var writerIdInfo = c.Writers.Where(x => x.WriterMail == p).Select(x => x.WriterId).FirstOrDefault();
            var values = headingManager.GetAllByWriter(writerIdInfo);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {

            List<SelectListItem> values = (from x in categoryManager.GetAll()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.vlc = values;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading entity)
        {
            string currentWriterMail = (string)Session["WriterMail"];
            var writerIdInfo = c.Writers.Where(x => x.WriterMail == currentWriterMail).Select(x => x.WriterId).FirstOrDefault();
            entity.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            entity.WriterId = writerIdInfo;
            entity.HeadingStatus = true;
            headingManager.Add(entity);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {
           
            List<SelectListItem> valueCategory = (from x in categoryManager.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();

            ViewBag.vlc = valueCategory;
            var headingValue = headingManager.GetById(id);
            return View(headingValue);
        }

        [HttpPost]
        public ActionResult UpdateHeading(Heading entity)
        {
            headingManager.Update(entity);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = headingManager.GetById(id);
            headingValue.HeadingStatus = false;
            headingManager.Delete(headingValue);
            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeading(int page=1)
        {
            var headings = headingManager.GetAll().ToPagedList(page, 4);
            return View(headings);
        }
    }
}