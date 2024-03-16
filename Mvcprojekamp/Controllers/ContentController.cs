using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvcprojekamp.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager cm=new ContentManager(new EFContentDal());
        public ActionResult Index()
        {
            return View();
        }
      
      
        public ActionResult GetAllContent(string p) 
        {
            var values=cm.GetContents(p);
;                return View(values);
            
           
        }
        public ActionResult ContentByHeading(int id)
        {
            var contentvalues=cm.GetContentsByHeadingId(id);
            return View(contentvalues);
        }
    }
}