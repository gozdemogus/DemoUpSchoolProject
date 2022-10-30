using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoUpSchoolProject.Models.Entites;

namespace DemoUpSchoolProject.Controllers
{
    public class ServicesController : Controller
    {
        PortfolioEntities2 db = new PortfolioEntities2();

        // GET: Services
        public ActionResult Index()
        {
            var values = db.TblServices.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddService()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddService(TblService p)
        {
            db.TblServices.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //parametre adı route config'de id olarak belirlendiği icin mutlaka onunla eslesmeli.
        public ActionResult DeleteService(int id)
        {
            var values = db.TblServices.Find(id);
            db.TblServices.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var values = db.TblServices.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateService(TblService p)
        {
            var values = db.TblServices.Find(p.ServicesID);
            values.Title = p.Title;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}