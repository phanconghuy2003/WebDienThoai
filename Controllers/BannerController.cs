using bandienthoai.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bandienthoai.Controllers
{
    public class BannerController : Controller
    {
        // GET: Banner
        public ActionResult Index()
        {
            return View();
        }
       
    }
}