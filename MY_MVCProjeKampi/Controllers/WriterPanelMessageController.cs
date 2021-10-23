using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete;
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
    public class WriterPanelMessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        Context c = new Context();
        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            var messageList = messageManager.GetAllInbox(p);
            return View(messageList);
        }

        public ActionResult Sendbox()
        {
            string p = (string)Session["WriterMail"];
            var messageList = messageManager.GetAllSendbox(p);
            return View(messageList);
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
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

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message entity)
        {
            string sender = (string)Session["WriterMail"];
            ValidationResult result = messageValidator.Validate(entity);
            if (result.IsValid)
            {
                entity.SenderMail = sender;
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
    }
}