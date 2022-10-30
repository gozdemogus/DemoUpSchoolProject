using DemoUpSchoolProject.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoUpSchoolProject.Controllers
{
    public class MessageController : Controller
    {
        PortfolioEntities2 db = new PortfolioEntities2();
        // GET: Message
        public ActionResult Inbox()
        {
            var mail = Session["MemberMail"].ToString();
            var values = db.TblMessages.Where(x => x.ReceiverMail == mail).ToList();
            return View(values);
        }

        public ActionResult Outbox()
        {
            var mail = Session["MemberMail"].ToString();
            var values=db.TblMessages.Where(x => x.SenderMail == mail).ToList();  
            return View(values);
        }

        [HttpGet]
        public ActionResult SendMessage()
        {
            return View();
        }


        [HttpPost]
        public ActionResult SendMessage(TblMessage tblMessage)
        {
            var mail = Session["MemberMail"].ToString();

            tblMessage.MessageDate=DateTime.Parse(DateTime.Now.ToShortDateString()); 
            tblMessage.SenderMail=mail;
            tblMessage.SenderNameSurname = db.TblMembers.Where(x => x.MemberMail == mail).Select(y=>y.MemberName + " " + y.MemberSurname).FirstOrDefault();
          tblMessage.ReceiverNameSurname= db.TblMembers.Where(x => x.MemberMail == tblMessage.ReceiverMail).Select(y => y.MemberName + " " + y.MemberSurname).FirstOrDefault();
            db.TblMessages.Add(tblMessage);
            db.SaveChanges();
            return RedirectToAction("Outbox");
        }

        public ActionResult MessageDetails()
        {
            return View();
        }
    }
}