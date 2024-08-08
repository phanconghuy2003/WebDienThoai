using bandienthoai.Common;
using bandienthoai.Models.DAO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bandienthoai.Models.EF;

namespace bandienthoai.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: Product
        public ActionResult Index(int page = 1, int PageSize = 1)
        {
           
            int TotalRecord = 0;
            var model = new SanPhamDAO().GetListAllProduct(ref TotalRecord, page, PageSize);

            ViewBag.page = page;
            ViewBag.Total = TotalRecord;
            int MaxPage = 5;
            int TotalPage = 0;
            TotalPage = (int)Math.Ceiling((double)(TotalRecord / PageSize));
            ViewBag.TotalPage = TotalPage;
            ViewBag.MaxPage = MaxPage;
            ViewBag.First = 1;
            ViewBag.Last = TotalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(model);
        }
        public ActionResult KhuyenMai(int page = 1, int PageSize = 1)
        {

            int TotalRecord = 0;
            var model = new SanPhamDAO().GetListAllKhuyenMai(ref TotalRecord, page, PageSize);

            ViewBag.page = page;
            ViewBag.Total = TotalRecord;
            int MaxPage = 5;
            int TotalPage = 0;
            TotalPage = (int)Math.Ceiling((double)(TotalRecord / PageSize));
            ViewBag.TotalPage = TotalPage;
            ViewBag.MaxPage = MaxPage;
            ViewBag.First = 1;
            ViewBag.Last = TotalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(model);
        }
        [ChildActionOnly]
        public PartialViewResult ProductCategory()
        {
            var model = new CategoryDAO().ListAll();
            return PartialView(model);
        }
        public JsonResult ListName(string q)
        {
            var data = new SanPhamDAO().ListName(q);
            return Json(new
            {
                kq= data,
                status = true
            },JsonRequestBehavior.AllowGet);
        }
        public ActionResult Category(long id, int page=1, int PageSize=1)
        {
            
            var dao = new CategoryDAO().ViewDetail(id);
            ViewBag.Category = dao;
            int TotalRecord = 0;
            var model = new SanPhamDAO().GetListProductById(id,ref TotalRecord, page, PageSize);
     
            ViewBag.page = page;
            ViewBag.Total = TotalRecord;
            int MaxPage = 5;
            int TotalPage = 0;
            TotalPage =(int)Math.Ceiling((double)(TotalRecord / PageSize));
            ViewBag.TotalPage = TotalPage;
            ViewBag.MaxPage = MaxPage;
            ViewBag.First = 1;
            ViewBag.Last = TotalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev= page - 1;
            return View(model);
        }
        //search
        public ActionResult Search(string Keyword, int page = 1, int PageSize = 1)
        {

            int TotalRecord = 0;
            var model = new SanPhamDAO().Search(Keyword, ref TotalRecord, page, PageSize);

            ViewBag.page = page;
            ViewBag.Total = TotalRecord;
            ViewBag.Keyword = Keyword;
            int MaxPage = 5;
            int TotalPage = 0;
            TotalPage = (int)Math.Ceiling((double)(TotalRecord / PageSize));
            ViewBag.TotalPage = TotalPage;
            ViewBag.MaxPage = MaxPage;
            ViewBag.First = 1;
            ViewBag.Last = TotalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(model);
        }
        //action for detail view and get list recommend item
        public ActionResult Detail(long id)
        {
            var dao = new SanPhamDAO();
          
            dao.update(id);
            var model=dao.ViewDetail(id);
            ViewBag.Category = new CategoryDAO().ViewDetail(model.LOAISANPHAM_ID);
            ViewBag.RelatedProduct = dao.GetListRelatedProducts(id);
            ViewBag.ListImage = dao.GetListImagetId(id);
            //try catch for no user have logged in yet
            try
            {
                //calling recommend function with param 1: itemID, param2: current userid
                ViewBag.Recommender = dao.Recommender(id, ((UserLogin)Session[CommonStants.USER_SESSION]).userID);
            }
            catch
            { 
                ViewBag.Recommender = new List<SANPHAM>();
            }
            return View(model);
        }
        //action for add rating data to rating table
        public JsonResult addRating(int id,int idsp)
        {
            Rating rating = new Rating();
            rating.Star = id;
            rating.IDUser = ((UserLogin)Session[CommonStants.USER_SESSION]).userID;
            rating.IDItem = idsp;
            var kq = new SanPhamDAO().insertStar(rating);
            return Json(new
            {
                status = kq
            }, JsonRequestBehavior.AllowGet);
        }
    }
}