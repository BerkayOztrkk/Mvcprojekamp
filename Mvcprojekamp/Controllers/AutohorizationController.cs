using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvcprojekamp.Controllers
{
    public class AutohorizationController : Controller
    {
        // GET: Autohorization
        AdminManager am = new AdminManager(new EFAdminDal());

        public ActionResult Index()
        {
            var adminvalues=am.GetAdmins();
            return View(adminvalues);
        }
    }
}