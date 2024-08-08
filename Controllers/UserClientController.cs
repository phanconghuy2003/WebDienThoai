
using bandienthoai.Common;
using bandienthoai.Models;
using bandienthoai.Models.DAO;
using bandienthoai.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace bandienthoai.Controllers
{
    public class UserClientController : Controller
    {
        // GET: User
      
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session[CommonStants.USER_SESSION] = null;
            return Redirect("/");
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {

                var dao = new UserDAO();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    var user = dao.GetByUserName(model.UserName);
                    var userSession = new UserLogin();
                    userSession.userName = user.TENTAIKHOAN;
                    userSession.userID = user.ID;
                    Session.Add(CommonStants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "TrangChu");
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
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập không đúng");

                }

            }
            return View(model);
        }
        [HttpPost]
        public ActionResult ForgetPass(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                if (!dao.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập không tồn tại!");
                }
               
                else
                {
                    var user = new TAIKHOAN();
                    user.TENTAIKHOAN = model.UserName;
                    user.EMAIL_TK = model.Email;

                    user.HOTEN = model.Name;
                    user.MATKHAU = Encryptor.MD5Hash(model.Password);
                    user.DIACHI_TK = model.Address;
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
                        model = new RegisterModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký thất bại!");
                    }
                }
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                if (dao.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("","Tên đăng nhập đã tồn tại!");
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
                  
                    user.HOTEN = model.Name;
                    user.MATKHAU = Encryptor.MD5Hash(model.Password);
                    user.DIACHI_TK = model.Address;
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
                    if (result>0)
                    {
                        ViewBag.Success = "Đăng ký thành công!";
                        model =new RegisterModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký thất bại!");
                    }
                }
            }
            return View(model);
        }
        public JsonResult LoadProvince()
        {
            var xmlDoc = XDocument.Load(Server.MapPath(@"~/Data/Province/Provinces.xml"));
            var xElementss = xmlDoc.Element("Root").Elements("Item").Where(x=>x.Attribute("type").Value=="province");
            var list = new List<ProvinceModel>();
            ProvinceModel province = null;
            foreach (var item in xElementss) { 
                province = new ProvinceModel();
                province.ID=int.Parse(item.Attribute("id").Value);
                province.Name = item.Attribute("value").Value;
                list.Add(province);
            }
            return Json(new {
                data = list, status = true

            });
        }

        public JsonResult LoadDistrict(int ProvinceID)
        {
            var xmlDoc = XDocument.Load(Server.MapPath(@"~/Data/Province/Provinces.xml"));
            var xe = xmlDoc.Element("Root").Elements("Item").Where(x => x.Attribute("type").Value == "province"&& int.Parse(x.Attribute("id").Value) == ProvinceID);
            var list = new List<DistrictModel>();
            DistrictModel district = null;
            foreach (var item in xe.Elements("Item").Where(x=>x.Attribute("type").Value == "district"))
            {
                 district = new DistrictModel();
                district.ID = int.Parse(item.Attribute("id").Value);
                district.Name = item.Attribute("value").Value;
                district.ProvinceID = int.Parse(item.Attribute("id").Value);
                list.Add(district);
            }
            return Json(new
            {
                data = list,
                status = true

            });
        }
    }
}