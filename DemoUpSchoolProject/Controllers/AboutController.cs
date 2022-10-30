using DemoUpSchoolProject.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoUpSchoolProject.Controllers
{
    public class AboutController : Controller
    {
        PortfolioEntities2 db = new PortfolioEntities2();
        [Authorize]
        // GET: About
        public ActionResult Index()
        {
            var values = db.TblAbouts.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(TblAbout p)
        {
            db.TblAbouts.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");   
        }

       public ActionResult DeleteAbout(int id)
        {
            var values = db.TblAbouts.Find(id);
            db.TblAbouts.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var values = db.TblAbouts.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateAbout(TblAbout tblAbout)
        {
            var values = db.TblAbouts.Find(tblAbout.AboutID);
            values.Description=tblAbout.Description;    
            values.ImageUrl=tblAbout.ImageUrl;  
            values.NameSurname= tblAbout.NameSurname;   
            values.Title=tblAbout.Title;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}