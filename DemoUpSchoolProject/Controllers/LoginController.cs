using DemoUpSchoolProject.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DemoUpSchoolProject.Controllers
{
    public class LoginController : Controller
    {
        PortfolioEntities2 db = new PortfolioEntities2();
        [HttpGet]
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblMember tblMember)
        {
            var values = db.TblMembers.FirstOrDefault(x => x.MemberMail == tblMember.MemberMail && x.MemberPassword == tblMember.MemberPassword);

            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.MemberMail, false);
                Session["MemberMail"] = tblMember.MemberMail;
                return RedirectToAction("Index", "About");
            }
            else
            {
                return RedirectToAction("Index");
            }
          
        }
    }
}