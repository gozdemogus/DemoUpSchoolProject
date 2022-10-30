using DemoUpSchoolProject.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoUpSchoolProject.Controllers
{
    public class MemberController : Controller
    {
        PortfolioEntities2 db = new PortfolioEntities2();
        // GET: Member
        public ActionResult Index()
        {
            var mail = Session["MemberMail"].ToString();
            var values = db.TblMembers.Where(x => x.MemberMail == mail).FirstOrDefault();
            ViewBag.name = values.MemberName;
            ViewBag.surname = values.MemberSurname;
            ViewBag.id = values.Member;
            return View();
        }
    }
}