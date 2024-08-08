using bandienthoai.Areas.Admin.Models;
using bandienthoai.Areas.Admin.Models.DAO;
using bandienthoai.Areas.Admin.Models.EF;
using bandienthoai.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bandienthoai.Areas.Admin.Controllers
{
    public class BannerController : BaseController
    {
        // GET: Admin/Banner
        public ActionResult Index()
        {
            var dao = new BannerDAO();
            ViewBag.listSlides = dao.GetListSlide(1);
            ViewBag.logo = dao.GetsrcLogo(0);

            return View();
        }

        //logo
        [HttpGet]
        
        public ActionResult Logo()
        {
            return View();
        }
        [HttpPost]
        public JsonResult SaveLogo(string data)
        {

            SLIDE sp = new SLIDE();
            sp.IMAGE = data;
            int result = 0;
            var kq = false;
            if (ModelState.IsValid)
            {
                var dao = new BannerDAO();
                var logo = dao.GetLogo();
                if (logo == null)
                {
                    var user = ((UserLogin)Session[CommonStants.USER_SESSION]);
                    sp.CREATEBY = user.userName;
                    sp.STATUS = 0;
                    dao.SaveSlide(sp, user.userName);
                }
                else
                {
                    dao.UpdateLogo(sp);
                }

                kq = true;

            }
            return Json(kq, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetListBanner()
        {
            var dao = new BannerDAO();
            var result = dao.GetListBanner();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SaveSlide(SLIDE sp)
        {
            int result = 0;
            bool kq = false;
            if (ModelState.IsValid)
            {
                var dao = new BannerDAO();
                var user = ((UserLogin)Session[CommonStants.USER_SESSION]);
                sp.CREATEBY = user.userName;
                sp.STATUS = 1;
                result = dao.SaveSlide(sp, user.userName);
                if (result == 1)
                {
                    SetAlert("Cập Nhật Thành Công!", "success");
                    kq = true;
                }
                else if (result == 2)
                {
                    SetAlert("Thêm Thành Công!", "success");
                    kq = true;
                }
                else
                    SetAlert("Thất Công!", "warning");

            }
            return Json(kq, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult SaveData(BannerModel sp)
        {
            int result = 0;
            bool kq = false;
            if (ModelState.IsValid)
            {
                var dao = new BannerDAO();
                var user = ((UserLogin)Session[CommonStants.USER_SESSION]);
                sp.TENTK = user.userID;
                result = dao.SaveData(sp, user.userName);
                if (result == 1)
                {
                    SetAlert("Cập Nhật Thành Công!", "success");
                    kq = true;
                }
                else if (result == 2)
                {
                    SetAlert("Thêm Thành Công!", "success");
                    kq = true;
                }
                else
                    SetAlert("Thất Công!", "warning");

            }
            return Json(kq, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Delete(int id)
        {
            var dao = new BannerDAO();

            var result = false;


            result = dao.Delete(id);
          

            return Json(result, JsonRequestBehavior.AllowGet);

        }


    }
}