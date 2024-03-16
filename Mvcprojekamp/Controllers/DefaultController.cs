using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvcprojekamp.Controllers
{

    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        ContentManager cm = new ContentManager(new EFContentDal());
        public ActionResult Headings()
        {
            var headinglist = hm.GetHeadingList();
            return View(headinglist);
        }
        public PartialViewResult Index(int id=0)
        {
            var contentlist = cm.GetContentsByHeadingId(id);
            return PartialView(contentlist);
        }
    }
}