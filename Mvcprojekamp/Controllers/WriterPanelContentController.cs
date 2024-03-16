using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvcprojekamp.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EFContentDal());
        Context c = new Context();
        public ActionResult MyContent(string p)
        {
           
            p=(string)Session["UserMail"];
            var writeridinfo=c.Writers.Where(x=>x.UserMail==p).Select(y=>y.WriterId).FirstOrDefault();   
            var contentvalues = cm.GetContentsByWriter(writeridinfo);
            return View(contentvalues);
         
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d=id;
            return View();
        } 
        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            string mail=(string)Session["UserMail"];
            var writeridinfo = c.Writers.Where(x => x.UserMail==mail).Select(y => y.WriterId).FirstOrDefault();
            p.ContentDate= DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterId=writeridinfo;
            p.ContentStatus=true;
            cm.ContentAdd(p);
            return RedirectToAction("MyContent");
        }
        public ActionResult ToDoList()
        {
            return View();
        }
    }
}