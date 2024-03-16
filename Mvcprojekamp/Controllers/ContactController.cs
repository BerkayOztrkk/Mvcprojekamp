using BusinessLayer.Concrete;
using BusinessLayer.Validation;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvcprojekamp.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm= new ContactManager(new EFContactDal());
        ContactValidator cv= new ContactValidator();

        [AllowAnonymous]
        public ActionResult Index()
        {
            var contactvalues = cm.GetContactList();
            return View(contactvalues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactvalues=cm.Getbyid(id);
            return View(contactvalues);
        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
    }
}