using System;
using bandienthoai.Areas.Admin.Models.DAO;
using bandienthoai.Areas.Admin.Models.EF;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bandienthoai.Common;
using System.IO;
using System.Text;
using bandienthoai.Areas.Admin.Models;

namespace bandienthoai.Areas.Admin.Controllers
{
    public class TinTucController : BaseController
    {
        // GET: Admin/TinTuc
        public ActionResult Index()
        {
            TinTucDAO dao = new TinTucDAO();


            var x = ((UserLogin)Session[CommonStants.USER_SESSION]).userID;
            var user = new UserDAO().ViewDetail(x);
          //  ViewBag.typeLoai = getTypeUserView(user);
            getTypeNews();
            var result = dao.listTintuc();
            //Add a Dummy Row.

            return View(result);
        }
        //public int getTypeUserView(TAIKHOAN user)
        //{
        //  //  var typeUser = new LoaiTaiKhoanDAO().GetTypeUserByID(user.LOAITAIKHOAN_ID);
        //    if (typeUser.TENLOAITK.ToLower() == "admin")
        //    {
        //        return 1;
        //    }
        //    else
        //        return 2;
        //}
        [HttpGet]
        public ActionResult Create()
        {
            getTypeNews();
            return View();
        }

        public void getTypeNews(long? selectedId = null)
        {
            var dao = new LoaiTinTucDAO();
            ViewBag.IDLOAITINTUC = new SelectList(dao.GetListTypeNews(), "IDLOAITINTUC", "TENLOAITIN", selectedId);
        }
        public FileStreamResult SaveData(string example)
        {
            //todo: add some data from your database into that string:
            var string_with_your_data = example;

            //Build your stream
            var byteArray = Encoding.ASCII.GetBytes(string_with_your_data);
            var stream = new MemoryStream(byteArray);

            //Returns a file that will match your value passed in (ie TestID2.txt)
            return File(stream, "text/plain", String.Format("{0}.cshtml", example));
        }


        public JsonResult Delete(int id)
        {
            var dao = new TinTucDAO();
            var line = dao.GetByID(id);
            string link = Server.MapPath("/Data/Content/" + line.TINTUC_ID + ".cshtml");
            dao.DeleteFile(link);
            bool value = dao.Delete(id);
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            var dao = new TinTucDAO().ViewDetail(id);


            return View(dao);
        }
        public int changeAn(int id)
        {
            var user = ((UserLogin)Session[CommonStants.USER_SESSION]).userName;
            var dao = new TinTucDAO();
            var kq = dao.ChangeStatus(id, user, true);
            return kq;
        }
        public int changeHien(int id)
        {
            var user = ((UserLogin)Session[CommonStants.USER_SESSION]).userName;
            var dao = new TinTucDAO();
            var kq = dao.ChangeStatus(id, user, false);
            return kq;
        }
        public int changeAnHien(int id)
        {
            var user = ((UserLogin)Session[CommonStants.USER_SESSION]).userName;
            var dao = new TinTucDAO();
            var type = dao.GetById(id);

            var kq = dao.ChangeStatus(id, user, !type.IS_DELETE);
            return kq;
        }
        [HttpPost]
        public ActionResult Edit(TINTUC tin)
        {
            if (ModelState.IsValid)
            {
                var dao = new TinTucDAO();

                tin.MODIFILEDBY = ((UserLogin)Session[CommonStants.USER_SESSION]).userName;
                var id = dao.Update(tin);
                if (id)
                {
                    SetAlert("Sửa thành công", "success");
                    return RedirectToAction("Index", "tin");
                }
                else
                {
                    SetAlert("Sửa không thành công", "danger");
                    ModelState.AddModelError("", "Cập nhật không thành Công!");
                }
            }
            return View("Index");

        }

        public string changeImage(long id, string picture)
        {
            if (id == null)
            {
                return "Mã không tồn tại";
            }
            var t = new TinTucDAO();
            var result = t.GetById(id);
            if (result == null)
            {
                return "Mã không tồn tại";
            }
            t.changeImage(id, picture);
            return "";
        }
        [HttpPost]
        public ActionResult Create(TinTucModel sp)
        {


            var dao = new TinTucDAO();
            var tk = dao.GetByTitle(sp.TIEUDE_TINTUC);

            if (tk != null)
            {
                SetAlert("Tin tức đã  tồn tại", "fail");
                return RedirectToAction("Index", "TinTuc");
            }

            //string txtContent = ViewBag.GhiChu;

            var txtContent = Request.Unvalidated.Form.Get("txtContent");

            // encode the data
            sp.CREATEBY = ((UserLogin)Session[CommonStants.USER_SESSION]).userName;
            sp.CREATEDATE = DateTime.Now;
            sp.IDTAIKHOAN = ((UserLogin)Session[CommonStants.USER_SESSION]).userID;

            decimal id = dao.Insert(sp);

            if (id > 0)
            {
                //var LastId = dao.getIDLastChild();
                //string exePath = System.AppContext.BaseDirectory + "\\Data\\Content\\" + namenew + ".html";
                string exePath = Server.MapPath("\\Data\\Content\\tt" + id + ".cshtml");
                FileStream fs = new FileStream(exePath, FileMode.Create);
                using (StreamWriter sw = new StreamWriter(fs))
                {

                    foreach (var s in txtContent)
                    {
                        sw.Write(s);
                    }
                    sw.Flush();

                }
                fs.Close();
                string link = "/Data/Content/tt" + id + ".html";
                dao.updatenoidung(link,id);
                SetAlert("Thêm Thành công", "success");
                return RedirectToAction("Index", "TinTuc");
            }
            else
            {
                ModelState.AddModelError("", "Thêm không thành công!");
            }


            return View("Index");

        }

    }
}