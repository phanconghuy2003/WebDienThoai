using bandienthoai.Areas.Admin.Models.DAO;
using bandienthoai.Areas.Admin.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bandienthoai.Common;
using System.IO;
using System.Text;
using Commom;
using bandienthoai.Areas.Admin.Models;

namespace bandienthoai.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product

        public ActionResult Index(string searching)
        {
            getNCC();
            getTypeProduct();
            var dao = new SanPhamDAO();
            var model = dao.GetListProduct();

            return View(model);
        }
        [HttpGet]
        [HasCredential(RoleID = "VIEW_PRODUCT")]
        public JsonResult DSSanPham()
        {
            var dao = new SanPhamDAO();
            var model = dao.GetListProduct();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public void getTypeProduct(long? selectedId = null)
        {
            var dao = new SanPhamDAO();
            ViewBag.LOAISANPHAM_ID = new SelectList(dao.getAllTypeProduct(), "LOAISANPHAM_ID", "TEN_LOAISANPHAM", selectedId);
        }
        public void getProductbyID(long selectedId)
        {
            var dao = new SanPhamDAO();
            ViewBag.LOAISANPHAM_ID = dao.getProductbyID(selectedId);
        }
        public void getNSX(long? selectedId = null)
        {
            var dao = new NhaSanXuatDAO();
            ViewBag.ID_NSX = new SelectList(dao.getAllNSX(), "ID_NSX", "TEN_NSX", selectedId);
        }
        public void getNCC(long? selectedId = null)
        {
            var dao = new NhaCungCapDAO();
            ViewBag.ID_NCC = new SelectList(dao.getAllNCC(), "ID_NCC", "TEN_NCC", selectedId);
        }
        [HttpDelete]
        [HasCredential(RoleID = "DELETE_PRODUCT")]
        public ActionResult Delete(int id)
        {
            var dao = new SanPhamDAO();
            var line = dao.GetByID(id);
            string link = Server.MapPath("/Data/Product/pro" + line.SANPHAM_ID + ".cshtml");
            dao.DeleteFile(link);
            dao.Delete(id);

            SetAlert("Xóa thành công", "success");
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            getTypeProduct();
            getNSX();
            getNCC();
            return View();

        }
        [HttpGet]
        [HasCredential(RoleID = "ADD_PRODUCT")]
        public ActionResult Update(decimal id)
        {
           
            var model = new SanPhamDAO().getsanphamByID(id);
            getTypeProduct((long)model.LOAISANPHAM_ID);
        
            getNSX(model.ID_NSX);
            getNCC(model.ID_NCC);
            
            return View(model);
        }
        [HttpGet]
        public ActionResult Filter()
        {
            var result = new SanPhamDAO().GetListProduct();

            return Json(new
            {
                status = result
            }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new SanPhamDAO().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
        [HttpPost, ValidateInput(false)]
        void insertimg(decimal id, string src)
        {
            if (src != null)
            {
                var img = new IMAGEPRODDUCT();
                var dao = new SanPhamDAO();
                img.IMAGE = src;
                img.IDPRODUCT = id;
                dao.InsertImg(img);
            }

        }
        //update
       
        [HttpPost]
        public ActionResult Update(ProductModel sp)
        {
            if (ModelState.IsValid)
            {
                
                var dao = new SanPhamDAO();
                var model = dao.GetByID((int)sp.SANPHAM_ID);

                if (model == null)
                {
                    SetAlert("Sản phẩm đã  tồn tại", "fail");
                    return RedirectToAction("Index", "Product");
                }

                //string txtContent = ViewBag.GhiChu;

                var gender = Request.Unvalidated.Form.Get("gender");
                if (gender == "Khóa")
                {
                    model.TRANGTHAI =false ;
                }
                else
                    model.TRANGTHAI =true ;
                model.MA_SANPHAM = sp.MA_SANPHAM;
                model.TEN_SANPHAM = sp.TEN_SANPHAM;
                model.LOAISANPHAM_ID = sp.LOAISANPHAM_ID;
                model.ID_NCC = sp.ID_NCC;
                model.ID_NSX = sp.ID_NSX;
                model.NOIDUNG = sp.NOIDUNG;
                model.TONTOITHIEU = sp.TONTOITHIEU;
                model.KHUYENMAI = sp.KHUYENMAI;
                model.SPDIKEM = sp.SPDIKEM;
                model.GIA_SANPHAM = sp.GIA_SANPHAM;
                model.HINHANH_SANPHAM = sp.HINHANH_SANPHAM;
                model.MOTA_SANPHAM = sp.MOTA_SANPHAM;
                model.SPDIKEM = sp.SPDIKEM;
                model.CREATEBY = ((UserLogin)Session[CommonStants.USER_SESSION]).userName;
                
             

                if (string.IsNullOrEmpty(sp.GHICHU_SANPHAM))
                {
                    model.GHICHU_SANPHAM = StringHelper.toUnsignString(sp.TEN_SANPHAM);
                }
                //hinh anh

                bool id = dao.Update(model);


                if (id ==true)
                {
                    dao.deleteImgById(sp.SANPHAM_ID);
                    insertimg(sp.SANPHAM_ID, sp.Image1);
                    insertimg(sp.SANPHAM_ID, sp.Image2);
                    insertimg(sp.SANPHAM_ID, sp.Image3);
                    insertimg(sp.SANPHAM_ID, sp.Image4);
                    insertimg(sp.SANPHAM_ID, sp.Image5);
                    insertimg(sp.SANPHAM_ID, sp.Image6);
               
                    SetAlert("Thêm Thành công", "success");
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công!");
                }
            }
            return View("Index");

        }
        [HasCredential(RoleID = "ADD_PRODUCT")]
        public ActionResult Create(ProductModel sp)
        {
            if (ModelState.IsValid)
            {
                var model = new SANPHAM();
                var dao = new SanPhamDAO();
                var tk = dao.GetByTitle(sp.TEN_SANPHAM);

                if (tk != null)
                {
                    SetAlert("Sản phẩm đã  tồn tại", "fail");
                    return RedirectToAction("Index", "Product");
                }

                model.MA_SANPHAM = sp.MA_SANPHAM;
                model.TEN_SANPHAM = sp.TEN_SANPHAM;
                model.LOAISANPHAM_ID = sp.LOAISANPHAM_ID;
                model.ID_NCC = sp.ID_NCC;
                model.ID_NSX = sp.ID_NSX;
                model.NOIDUNG = sp.NOIDUNG;
                model.TONTOITHIEU = sp.TONTOITHIEU;
                model.MOTA_SANPHAM = sp.MOTA_SANPHAM;
                model.KHUYENMAI = sp.KHUYENMAI;
                model.TRANGTHAI = sp.TRANGTHAI;
                model.SPDIKEM = sp.SPDIKEM;
                model.GIA_SANPHAM = sp.GIA_SANPHAM;
                model.HINHANH_SANPHAM = sp.HINHANH_SANPHAM;

                model.CREATEBY = ((UserLogin)Session[CommonStants.USER_SESSION]).userName;
                model.CREATEDATE = DateTime.Now;
                model.LUOTXEM = 0;
               
                if (string.IsNullOrEmpty(sp.GHICHU_SANPHAM))
                {
                    model.GHICHU_SANPHAM = StringHelper.toUnsignString(sp.TEN_SANPHAM);
                }
                //hinh anh
                
                decimal id = dao.Insert(model);
             
                    
                if (id > 0)
                {
                    insertimg(id, sp.Image1);
                    insertimg(id, sp.Image2);
                    insertimg(id, sp.Image3);
                    insertimg(id, sp.Image4);
                    insertimg(id, sp.Image5);
                    insertimg(id, sp.Image6);
                    SetAlert("Thêm Thành công", "success");
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công!");
                }
            }
            return View("Index");

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
    }
}

