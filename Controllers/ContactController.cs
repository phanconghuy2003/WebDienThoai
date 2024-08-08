using bandienthoai.Models.DAO;
using bandienthoai.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bandienthoai.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            var dao = new ContactDAO().getContact();
            return View(dao);
        }
        public JsonResult Send(string name, string sdt, string email,string title,string content,string address)
        {
            FEEDBACK FB = new FEEDBACK();
            FB.NAME = name;
            FB.PHONE = sdt;
            FB.NOIDUNG = content;
            FB.EMAIL = email;
            FB.TITLE = title;
            FB.ADDRESS = address;
           var id= new ContactDAO().InsertFeedBack(FB);
            if (id>0)
            {
                return Json(new
                {
                    status = true
                });
            }
            return Json(new
            {
                status = false
            });
        }
    }
}