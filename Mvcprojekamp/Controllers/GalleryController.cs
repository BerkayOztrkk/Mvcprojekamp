using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvcprojekamp.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
       ImageManager ım= new ImageManager(new EFImageDal());
        public ActionResult Index()
        {
            var files=ım.GetImageFiles();
            return View(files);
        }
    }
}