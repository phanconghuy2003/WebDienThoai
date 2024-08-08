using bandienthoai.Models;
using bandienthoai.Models.DAO;
using bandienthoai.Models.EF;
using Commom;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using bandienthoai.Common;

namespace bandienthoai.Controllers
{
    public class CartController : Controller
    {
        private string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];

            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
                return View(list);
        }
        // thanh toan online
        public ActionResult Paypal()
        {
            return View();
        }
        //thanh toán
        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[CartSession];

            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult Payment(string shipName, string mobile, string email, string address)
        {
            var id = (long)-1;
            decimal total = 0;
            var order = new ORDER();
           var user= (UserLogin)Session[CommonStants.USER_SESSION];
            if (user != null)
            {
                order.CUSTOMERID = user.userID;
            }
       
            order.CREATEDATE = DateTime.Now;
            order.SHIPDDRESS = address;
            order.SHIPNAME = shipName;
            order.SHIPMOBILE = mobile;
            order.SHIPEMAIL = email;
            try
            {
                 id= new OrderDAO().Insert(order);
                var sessionCart = (List<CartItem>)Session[CartSession];

                for (int i=0;i<sessionCart.Count/2;i++)
                {
                    for (int j = i+1; j < sessionCart.Count; j++)
                    {
                        var re = new RecommenderDAO();
                        re.insert(sessionCart[i].Product.SANPHAM_ID, sessionCart[j].Product.SANPHAM_ID);
                    }

                }

                var orderDetailDAO = new OrderDetailDAO();
                foreach (var item in sessionCart)
                {
                    var orderDetail = new ORDERDETAIL();
                    orderDetail.PRODUCTID = item.Product.SANPHAM_ID;
                    orderDetail.GIAMGIA = item.Product.KHUYENMAI;
                    orderDetail.ORDERID = id;
                   
                    orderDetail.PRICE = (long)item.Product.GIA_SANPHAM;
                    orderDetail.QUANTITY = item.Quantity;
                    orderDetailDAO.Insert(orderDetail);
                    total += (item.Product.GIA_SANPHAM * item.Quantity);
                }
                string content = System.IO.File.ReadAllText(Server.MapPath("~/Assets/client/teamplet/NewOrder.html"));
                content = content.Replace("{{customereName}}", shipName);
                content = content.Replace("{{Phone}}", mobile);
                content = content.Replace("{{Email}}", email);

                content = content.Replace("{{Address}}", address);
                content = content.Replace("{{Total}}", total.ToString("N0"));


                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"];
                new MailHelper().SenMail(toEmail, "Đơn hàng mới từ Shop", content);

                new MailHelper().SenMail(email,"Đơn hàng mới từ Shop", content);
                Session[CartSession] = null;
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = "Có lỗi xảy ra khi xử lý đơn hàng.";
                return RedirectToAction("Index","TrangChu");

            }
            return Redirect("/hoan-thanh?id="+id);
        }
        //hoan thành
        public ActionResult Success(long id)
        {
            var model = new OrderDAO().GetOderbyID(id);
            return View(model);
        }
        // xóa gio hang
        public JsonResult DeleteAll()
        {
           
            Session[CartSession] = null;
            
            return Json(new
            {
                status = true
            });
        }
        // xóa từng sp gio hang
        public JsonResult Delete(long id)
        {

            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Product.SANPHAM_ID == id);
            Session[CartSession]=sessionCart;
            return Json(new
            {
                status = true
            });
        }
        // update gio hang
        public JsonResult  Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];
            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.SANPHAM_ID == item.Product.SANPHAM_ID);
                if (jsonItem!=null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public ActionResult AddItem(long ProductId, int quantity)
        {
            var cart = Session[CartSession];
            var product = new SanPhamDAO().ViewDetail(ProductId);
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Product.SANPHAM_ID == ProductId))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.SANPHAM_ID == ProductId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    //tao doi tuong cartitem
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    //them vào list

                    list.Add(item);
                }

            }
            else
            {

                //tao doi tuong cartitem
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                // gans vao sesion
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }
        public JsonResult AddCart(long id)
        {
            var cart = Session[CartSession];
            var product = new SanPhamDAO().ViewDetail(id);
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Product.SANPHAM_ID == id))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.SANPHAM_ID == id)
                        {
                            item.Quantity += 1;
                        }
                    }
                }
                else
                {
                    //tao doi tuong cartitem
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = 1;
                    //them vào list

                    list.Add(item);
                }

            }
            else
            {

                //tao doi tuong cartitem
                var item = new CartItem();
                item.Product = product;
                item.Quantity = 1;
                var list = new List<CartItem>();
                list.Add(item);
                // gans vao sesion
                Session[CartSession] = list;
            
            }
            return Json(new
            {
                status = true
            });
        }
       
    }
}