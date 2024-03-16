using BusinessLayer.Concrete;
using BusinessLayer.Validation;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Mvcprojekamp.Controllers
{
    public class MessageController : Controller
    {

        MessageValidator messagevalidator = new MessageValidator();
        MessageManager mm = new MessageManager(new EFMessageDal());

        [Authorize]
        public ActionResult Inbox(string p)
        {
            var messagelist=mm.GetListInbox(p);
            return View(messagelist);
        }
     
        public ActionResult SendBox(string p) 
        { 
            var messagelist=mm.GetListSendbox(p);
            return View(messagelist);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.Getbyid(id);
            return View(values);
        }
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = mm.Getbyid(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult results = messagevalidator.Validate(p);
            if (results.IsValid) { 
            p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
           
            mm.MessageAdd(p);
            return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);

                }
            }
            return View();
        }
       
    }
}