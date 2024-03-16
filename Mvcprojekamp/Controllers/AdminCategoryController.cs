using BusinessLayer.Concrete;
using BusinessLayer.Validation;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvcprojekamp.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        [Authorize(Roles="T")]
        public ActionResult Index()
        {
            var categoryvalues = cm.GetCategoryList();
            return View(categoryvalues);
        }
        [HttpGet]
        public ActionResult AddCategory()
        { return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category p)
        { 
            CategoryValidator ctgr = new CategoryValidator();
            ValidationResult results= ctgr.Validate(p);
            if (results.IsValid)
            {
                cm.CategoryAdd(p);
                return RedirectToAction("Index");
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
        public ActionResult DeleteCategory(int id)
        {
            var categoryvalue=cm.Getbyid(id);
            cm.CategoryDelete(categoryvalue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var categoryvalues = cm.Getbyid(id);
            return View(categoryvalues);
            
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category p)
        {
            cm.CategoryUpdate(p);
            return RedirectToAction("Index");
        }
    }
}