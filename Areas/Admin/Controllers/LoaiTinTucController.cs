using bandienthoai.Areas.Admin.Models;
using bandienthoai.Areas.Admin.Models.DAO;
using bandienthoai.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bandienthoai.Areas.Admin.Controllers
{
    public class LoaiTinTucController : BaseController
    {
        // GET: Admin/LoaiTinTuc
        public ActionResult Index()
        {

            return View();
        }
        public JsonResult GetListLoaiTin()
        {
            var dao = new LoaiTinTucDAO();
            var result = dao.GetListTypeNews();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetListTypeNewsByID(long ID)
        {
            var value = new LoaiTinTucDAO().GetListTypeNewsByID(ID);
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public void getallTypeNews(long? selectedId = null)
        {
            var dao = new LoaiTinTucDAO();
            ViewBag.IDLOAITINTUC = new SelectList(dao.GetListTypeNews(), "IDLOAITINTUC", "TENLOAITIN", selectedId);
        }
        [HttpPost]
        public ActionResult SaveData(LoaiTinTucModel sp)
        {
            int result = 0;
            bool kq = false;
            if (ModelState.IsValid)
            {
                var dao = new LoaiTinTucDAO();
                string user = ((UserLogin)Session[CommonStants.USER_SESSION]).userName;

                result = dao.SaveData(sp, user);
                if (result == 1)
                {

                    kq = true;
                }
                else if (result == 2)
                {

                    kq = true;
                }

            }
            return Json(kq, JsonRequestBehavior.AllowGet);

        }
        public JsonResult Delete(int id)
        {
            var dao = new LoaiTinTucDAO();
            bool value = dao.Delete(id);
            return Json(value, JsonRequestBehavior.AllowGet);
        }
    }
}