using bandienthoai.Areas.Admin.Models;
using bandienthoai.Common;
using bandienthoai.Areas.Admin.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bandienthoai.Areas.Admin.Models.EF;

namespace bandienthoai.Areas.Admin.Controllers
{
    public class NhaSanXuatController : BaseController
    {
        // GET: Admin/NhaSanXuat
        public ActionResult Index()
        {

            var x = ((UserLogin)Session[CommonStants.USER_SESSION]).userID;
            var user = new UserDAO().ViewDetail(x);
           // ViewBag.typeLoai = getTypeUserView(user);

            return View();
        }

        //public int getTypeUserView(TAIKHOAN user)
        //{
        //    //var typeUser = new LoaiTaiKhoanDAO().GetTypeUserByID(user.LOAITAIKHOAN_ID);
        //    if (typeUser.TENLOAITK.ToLower() == "admin")
        //    {
        //        return 1;
        //    }
        //    else
        //        return 2;
        //}
        public JsonResult GetListNhaSX()
        {
            var dao = new NhaSanXuatDAO();
            var result = dao.GetListNhaSX();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetListNSXByID(int id)
        {
            var dao = new NhaSanXuatDAO();
            var result = dao.GetListNSXByID(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //delete
        public JsonResult Delete(int id)
        {
            var dao = new NhaSanXuatDAO();
            bool value = dao.Delete(id);

            if (value)
                SetAlert("Xóa thành công", "success");
            else
                SetAlert("Xóa thất bại", "success");
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SaveData(NhaSanXuatModel sp)
        {
            int result = 0;
            bool kq = false;
            if (ModelState.IsValid)
            {
                var dao = new NhaSanXuatDAO();
                string user = ((UserLogin)Session[CommonStants.USER_SESSION]).userName;

                result = dao.SaveData(sp, user);
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
        //Ẩn hiện table
        public int changeAn(int id)
        {
            var user = ((UserLogin)Session[CommonStants.USER_SESSION]).userName;
            var dao = new NhaSanXuatDAO();
            var kq = dao.ChangeStatus(id, user, true);
            return kq;
        }
        public int changeHien(int id)
        {
            var user = ((UserLogin)Session[CommonStants.USER_SESSION]).userName;
            var dao = new NhaSanXuatDAO();
            var kq = dao.ChangeStatus(id, user, false);
            return kq;
        }
        public int changeAnHien(int id)
        {
            var user = ((UserLogin)Session[CommonStants.USER_SESSION]).userName;
            var dao = new NhaSanXuatDAO();
            var type = dao.GetById(id);

            var kq = dao.ChangeStatus(id, user, !type.IS_DELETE);
            return kq;
        }
    }
}