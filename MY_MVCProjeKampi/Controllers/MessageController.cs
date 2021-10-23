using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MY_MVCProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator rules = new MessageValidator();
        public ActionResult Index(string p)
        {
            var messageValues = messageManager.GetAllInbox(p);
            return View(messageValues);
        }

        public ActionResult Sendbox(string p)
        {
            var messageValues = messageManager.GetAllSendbox(p);
            return View(messageValues);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message entity)
        {
            ValidationResult result = rules.Validate(entity);
            if (result.IsValid)
            {
                entity.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.Add(entity);
                return RedirectToAction("Sendbox");
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

        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = messageManager.GetById(id);
            return View(values);
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = messageManager.GetById(id);
            return View(values);
        }
    }
}