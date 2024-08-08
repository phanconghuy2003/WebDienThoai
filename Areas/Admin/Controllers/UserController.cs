using bandienthoai.Areas.Admin.Models.DAO;
using bandienthoai.Areas.Admin.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using bandienthoai.Common;
using System.Web.Script.Serialization;
using bandienthoai.Areas.Admin.Models;

namespace bandienthoai.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        [HasCredential(RoleID = "VIEW_USER")]
        public ActionResult Index()
        {
            getallTypeUser();
            var dao = new UserDAO();
            var x = ((UserLogin)Session[CommonStants.USER_SESSION]).userID;
            var user = new UserDAO().ViewDetail(x);
            //ViewBag.typeLoai = getTypeUserView(user);
            ViewBag.IDUser = x;
            //var model = dao.listuser(page, pageSize);
            var model = dao.GetLoaiTaiKhoan();
            return View(model);
        }
        public void getallTypeUser(long? selectedId = null)
        {
            var dao = new LoaiTaiKhoanDAO();
            ViewBag.IDLOAITAIKHOAN = new SelectList(dao.GetListLoaiTK(), "IDLOAITAIKHOAN", "TENLOAITAIKHOAN", selectedId);
        }
        [HttpGet]
        [HasCredential(RoleID = "ADD_USER")]
        public ActionResult Create(long? selectedId = null)
        {
            var dao = new UserDAO();
            var result = dao.getAllTypeUser();

            ViewBag.LOAITAIKHOAN_ID = new SelectList(result, "ID", "TENLOAITK", selectedId);
            return View();
        }
        [HttpPost]
        [HasCredential(RoleID = "ADD_USER")]
       
       
            public ActionResult Create(UserViewModel model)
            {
            var d = new UserDAO();
            var r = d.getAllTypeUser();

            ViewBag.LOAITAIKHOAN_ID = new SelectList(r, "ID", "TENLOAITK");
            if (ModelState.IsValid)
                {
               
                    var dao = new UserDAO();
                    if (dao.CheckUserName(model.UserName))
                    {
                        ModelState.AddModelError("", "Tên đăng nhập đã tồn tại!");
                    }
                    else if (dao.CheckEmail(model.Email))
                    {
                        ModelState.AddModelError("", "Email đã tồn tại!");
                    }
                    else
                    {
                        var user = new TAIKHOAN();
                        user.TENTAIKHOAN = model.UserName;
                        user.EMAIL_TK = model.Email;
                    user.USERGROUPID = Request.Form.Get("LOAITAIKHOAN_ID");
                        user.HOTEN = model.Name;
                        user.MATKHAU = Encryptor.MD5Hash(model.Password);
                      
                        user.SDT = model.Phone;
                        if (!string.IsNullOrEmpty(model.Province))
                        {
                            user.PROVINCEID = int.Parse(model.Province);
                        }
                        if (!string.IsNullOrEmpty(model.District))
                        {
                            user.DISTRICTID = int.Parse(model.District);
                        }


                        user.CREATEDATE = DateTime.Now;
                        user.STATUS = true;
                        var result = dao.Insert(user);
                        if (result > 0)
                        {
                            ViewBag.Success = "Đăng ký thành công!";
                            model = new UserViewModel();
                        }
                        else
                        {
                            ModelState.AddModelError("", "Đăng ký thất bại!");
                        }
                    }
               
            }
            return View(model);
        }
        //Phân Quyền
        [HttpPost]
        public JsonResult AddRole(string id, string list)
        {
            if (ModelState.IsValid)
            {
                var jsonList = new JavaScriptSerializer().Deserialize<List<String>>(list);
                var dao = new UserDAO();
             bool kq= dao.InsertRole(id, jsonList);
                var model = dao.getAllTypeUser();
            }

           return Json(new
            {
               
                status = true

            });
        }
        [HttpGet]
        [HasCredential(RoleID = "PHAN_QUYEN")]
        public ActionResult PhanQuyen(long? selectedId = null)
        {
            var dao = new UserDAO();
            var model = dao.getmod();
            ViewBag.ListTypeUser = new SelectList(model, "ID", "TENLOAITK", selectedId);
            ViewBag.ListRole = dao.GetListAllRole();
            return View();
        }
        public void GetListRole(string selectedId="")
        {
            var dao = new UserDAO();
            ViewBag.ListRole = dao.GetListRole(selectedId);
        }
       
        //Get ROle theo id
        public JsonResult GetRole(string id)
        {
            var list = new UserDAO().GetRoleById(id);
           
            return Json(new
            {
                data = list,
                status = true

            });
        }
      
        [HttpGet]
        [HasCredential(RoleID = "EDIT_USER")]
        public ActionResult Edit(long selectedId)
        {
            var dao = new UserDAO();
            var result = dao.getAllTypeUser();

            ViewBag.LOAITAIKHOAN_ID = new SelectList(result, "ID", "TENLOAITK", selectedId);
            var user = new UserDAO().ViewDetail(selectedId);
           
          //  ViewBag.typeLoai = getTypeUserView(user);
            return View(user);
        }
        [HttpPost]
        [HasCredential(RoleID = "EDIT_USER")]
         public ActionResult Edit(UserViewModel model)
            {
                var d = new UserDAO();
                var r = d.getAllTypeUser();
            model.IDTypeUser = Request.Form.Get("LOAITAIKHOAN_ID");
            
                    
           
            ViewBag.LOAITAIKHOAN_ID = new SelectList(r, "ID", "TENLOAITK");
                if (ModelState.IsValid)
                {
                
                    var dao = new UserDAO();
                    if (!dao.CheckUserName(model.UserName))
                    {
                        ModelState.AddModelError("", "Tên đăng nhập đã tồn tại!");
                    }
                   
                    else
                    {
                    var tmp = new UserDAO().GetByUserName(model.UserName);
                    var user = new TAIKHOAN();
                    if (Encryptor.MD5Hash(model.PasswordOld) == tmp.MATKHAU)
                    {


                        user.ID = tmp.ID;
                        user.TENTAIKHOAN = model.UserName;
                        user.EMAIL_TK = model.Email;
                        user.USERGROUPID = Request.Form.Get("LOAITAIKHOAN_ID");
                        user.HOTEN = model.Name;
                        if (model.Password!="quocquoc")
                        {
                            user.MATKHAU = Encryptor.MD5Hash(model.Password);
                        }
                        else
                        {
                            user.MATKHAU = tmp.MATKHAU;
                        }
                     
                        user.SDT = model.Phone;
                        if (!string.IsNullOrEmpty(model.Province))
                        {
                            user.PROVINCEID = int.Parse(model.Province);
                        }
                        else
                            user.PROVINCEID = tmp.PROVINCEID;
                        if (!string.IsNullOrEmpty(model.District))
                        {
                            user.DISTRICTID = int.Parse(model.District);
                        }
                        else
                            user.DISTRICTID = tmp.DISTRICTID;
                           user.CREATEDATE = DateTime.Now;
                        user.STATUS = true;
                        var result = dao.Update(user);
                        if (result)
                        {
                            ViewBag.Success = "Cập nhật thành công!";
                            model = new UserViewModel();
                        }
                        else
                        {
                            ModelState.AddModelError("", "Cập nhật thất bại!");
                        }
                    }
                }

            }
                return View(model);
            }
        //[HttpDelete]
        //public ActionResult Delete(int id)
        //{
        //    var dao = new UserDAO();
        //    var tk = dao.GetByID(id);
        //    if (tk.TENTAIKHOAN.ToLower() == "admin")
        //    {
        //        SetAlert("Tài khoản Admin không được xóa", "success");
        //    }
        //    else { 
        //   dao.Delete(id);
        //    SetAlert("Xóa thành công", "success");
        //    }
        //    return RedirectToAction("Index");

            //}
        [HasCredential(RoleID = "DELETE_USER")]
        public JsonResult Delete(int id)
        {
            var dao = new UserDAO();
            var tk = dao.GetByID(id);
            var result = false;
            if (tk.TENTAIKHOAN.ToLower() == "admin")
            {
                SetAlert("Tài khoản Admin không được xóa", "success");
            }
            else
            {
                dao.Delete(id);
                result = true;
                SetAlert("Xóa thành công", "success");
            }
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        [HasCredential(RoleID = "EDIT_USER")]
        public JsonResult ChangeStatus(long id)
        {
            var result = new UserDAO().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
        [HttpGet]
        [HasCredential(RoleID = "VIEW_USER")]
        public void getLoaiTK(long id)
        {
            var result = new UserDAO().GetLoaiTaiKhoanByID(id);
            ViewBag.LOAITAIKHOAN_ID = result.ToList();
        }
        //[HttpGet]
        //public ActionResult checkTaiKhoan(long id)
        //{
        //    return
        //}
    }

}