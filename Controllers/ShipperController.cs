using bandienthoai.Models;
using bandienthoai.Models.DAO;
using bandienthoai.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bandienthoai.Models.EF;

namespace bandienthoai.Controllers
{
    public class ShipperController : Controller
    {
        // GET: Shipper
      
        public ActionResult Index()
        {
            var model = new ShipperDAO().GetListOrder(2);
            var user = Session[CommonStants.USER_SESSION];
            if (user == null)
                return RedirectToAction("DangNhap", "Shipper");
            return View(model);
        }
        public ActionResult Logout()
        {
            Session[CommonStants.USER_SESSION] = null;
            return Redirect("/Shipper/DangNhap");
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        
        public ActionResult DetailShipper(int id)
        {
            var model = new ShipperDAO().GetDetailOrderbyID(id);
            ViewBag.ListDetailOrder = new OrderDAO().GetDetailOderbyID(id);
            var user = Session[CommonStants.USER_SESSION];
            if (user == null)
                return RedirectToAction("DangNhap", "Shipper");
            return View(model);
        }
        public ActionResult GiaoHangShipper()
        {
            
            var user = (UserLogin)Session[CommonStants.USER_SESSION];
            if (user == null)
                return RedirectToAction("DangNhap", "Shipper");
            var dao = new ShipperDAO();
            var id = dao.getshipper(user.userName);
            var model = new ShipperDAO().GetDetailOrderbyID(id);
           
            ViewBag.ListDetailOrder = new OrderDAO().GetDetailOderbyID(id);
            return View(model);
        }
        public JsonResult UpdateOrder(int id)
        {
            var user = (UserLogin)Session[CommonStants.USER_SESSION];
            var model = new OrderDAO().UpdateOrder(id, 6);
            var ship = new ShipperDAO().Dagiao(user.userName);
            return Json(new
            {
                status = model
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult InsertShipper(int id)
        {
            var kq = false;
          
            var user =(UserLogin)Session[CommonStants.USER_SESSION];
            if (user != null)
            {
              var  l = new OrderDAO().checkOrder(user.userName);
                if (l ==null)
                {
                    var model = new SHIPPER();
                    model.USERNAME = user.userName;
                    model.ORDERID = id;
                    kq = new OrderDAO().InsertShipper(model);
                    new OrderDAO().UpdateOrder(id, 5);
                }
              
            }

            return Json(new
            {
                status = kq
           
            },JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DangNhap(LoginModel model)
        {
            if (ModelState.IsValid)
            {

                var dao = new UserDAO();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password),true);
                if (result == 1)
                {
                    var user = dao.GetByUserName(model.UserName);
                    var userSession = new UserLogin();
                    userSession.userName = user.TENTAIKHOAN;
                    userSession.userID = user.ID;
                    Session.Add(CommonStants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Shipper");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại!");

                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản bị khóa!");

                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Sai mật khẩu!");

                }
                else if (result == -3)
                {
                    ModelState.AddModelError("", "Tài khoản bạn không được quyền!");
                    //Redirect("DangNhap");

                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập không đúng");

                }

            }
            return View();
        }
    }
}