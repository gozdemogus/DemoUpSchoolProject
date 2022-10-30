using DemoUpSchoolProject.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace DemoUpSchoolProject.Controllers
{
    public class StatisticController : Controller
    {
        PortfolioEntities2 db = new PortfolioEntities2();
        // GET: Statistic
        public ActionResult Index()
        {
            ViewBag.v1 = db.TblTestimonials.Count();
            ViewBag.v2 = db.TblTestimonials.Where(x=>x.City=="İstanbul").Count();
            ViewBag.v3 = db.TblTestimonials.Where(x => x.Profession != "Mühendis").Count();
            ViewBag.v4 = db.TblTestimonials.Where(x => x.City == "Trabzon").Select(y => y.NameSurname).FirstOrDefault();
            ViewBag.v5 = db.TblTestimonials.Average(x => x.Balance);
            return View();
        }
    }
}