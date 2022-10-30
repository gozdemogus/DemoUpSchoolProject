using DemoUpSchoolProject.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoUpSchoolProject.Controllers
{
    public class UserController : Controller
    {
        PortfolioEntities2 db = new PortfolioEntities2();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Partial1()
        {
            return PartialView();
        }

        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }

        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public PartialViewResult AboutPartial()
        {
            var values = db.TblAbouts.ToList();
            return PartialView(values);
        }

        public PartialViewResult ServicePartial()
        {
            var values = db.TblServices.ToList();
            return PartialView(values);
        }
    }
}