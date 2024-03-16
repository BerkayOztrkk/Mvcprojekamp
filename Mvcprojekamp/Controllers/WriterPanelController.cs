using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using BusinessLayer.Validation;
using FluentValidation.Results;

namespace Mvcprojekamp.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        WriterManager wm=new WriterManager(new EFWriterDal());
        WriterValidator writervalidator = new WriterValidator();
        Context c = new Context();
        int writeridinfo;
        int id;
        [HttpGet]
        public ActionResult WriterProfile(int id=0)
        {
            string p=(string)Session["UserMail"];
         
           id = c.Writers.Where(x => x.UserMail==p).Select(y => y.WriterId).FirstOrDefault();
            var writervalue=wm.GetByid(id);
            
            return View(writervalue);
        }
        [HttpPost]
        public ActionResult WriterProfile(Writer p)
        {
            ValidationResult results = writervalidator.Validate(p);
            if (results.IsValid)
            {
                wm.WriterUpdate(p);
                return RedirectToAction("WriterProfile");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();


        }

        public ActionResult MyHeading(string p)
        {
            string deger = (string)Session["UserMail"];
            p=(string)Session["UserMail"];
            var writeridinfo =c.Writers.Where(x=>x.UserMail==p).Select(y=>y.WriterId).FirstOrDefault();
           
           var values = hm.GetHeadingListbyWriter(writeridinfo);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
           
       
            List<SelectListItem> valuecategory = (from x in cm.GetCategoryList()
                                                  select new SelectListItem
                                                  {
                                                      Text=x.CategoryName,
                                                      Value=x.CategoryId.ToString(),

                                                  }).ToList();
            ViewBag.vlc=valuecategory;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {
            string writermailinfo = (string)Session["UserMail"];
            var writeridinfo = c.Writers.Where(x => x.UserMail==writermailinfo).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.d=writeridinfo;
            p.HeadingDate= DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterId= 4;
            p.HeadingStatus=true;
            hm.HeadingAdd(p);
            return RedirectToAction("MyHeading");
        }
        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetCategoryList()
                                                  select new SelectListItem
                                                  {
                                                      Text=x.CategoryName,
                                                      Value=x.CategoryId.ToString(),

                                                  }).ToList();
            ViewBag.vlc = valuecategory;
            var HeadingValue = hm.Getbyid(id);
            return View(HeadingValue);

        }
        [HttpPost]
        public ActionResult UpdateHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteHeading(int id)
        {
            var HeadingValues = hm.Getbyid(id);
            HeadingValues.HeadingStatus=false;
            hm.HeadingDelete(HeadingValues);
            return RedirectToAction("MyHeading");
        }
        public ActionResult AllHeading(int p=1)
        {
            var headings=hm.GetHeadingList().ToPagedList(p,4);
            return View(headings);
        }

    }
}
//}<customErrors mode="On">

//          <error statusCode="404" redirect="/ErrorPage/Page404/"/>


//      </customErrors>