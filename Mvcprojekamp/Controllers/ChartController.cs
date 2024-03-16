using Mvcprojekamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvcprojekamp.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult kategorichart()
        {
            return Json(BlogList(),JsonRequestBehavior.AllowGet);
        }
        public List<Kategori> BlogList()
        {
            List<Kategori> kategoris = new List<Kategori>();
            kategoris.Add(new Kategori()
            {
                CategoryName="Yazılım",
                CategoryCount=8
            });
            kategoris.Add(new Kategori()
            {
                CategoryName="Seyahat",
                CategoryCount=5
            });
            kategoris.Add(new Kategori()
            {
                CategoryName="Spor",
                CategoryCount=1
            });
            return kategoris;

        }
    }
}