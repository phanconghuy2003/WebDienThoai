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
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace bandienthoai.Areas.Admin.Controllers
{
    public class NhapHangController : BaseController
    {
        // GET: Admin/NhapHang
        public ActionResult Index(bool all=true)
        {
            var listProduct = new SanPhamDAO().GetListProduct(all);
            //ViewBag.countBill = countncc(listProduct);
            ViewBag.ChedoView = all;
            return View(listProduct);
        }
        //update nhap
        public JsonResult UpdateBill(int id)
        {
            var kq = new NhapHangDAO().GetStatus(id);

            var dao = false;
            if (kq == 0)
            {
                dao = new NhapHangDAO().UpdateBill(id);
            }

            return Json(new
            {
                status = dao,

            }, JsonRequestBehavior.AllowGet);
        }
            [HttpDelete]
        public ActionResult Delete(int id)
        {
            var kq = new NhapHangDAO().GetStatus(id);

            var dao = false;
            if (kq == 0)
            {
                dao = new NhapHangDAO().Delete(id);
            }
            if (dao)
            {
                SetAlert("Xóa thành công", "success");
            }
            else
                SetAlert("Xóa thất bại", "success");

            return RedirectToAction("Index");
        }
    
        public JsonResult UpdateHoadon(int id,int? gia,int? soluong )
        {
            var kq = new NhapHangDAO().GetStatus(id);
          
            var dao = false;
            if (kq==0)
            {
                dao = new NhapHangDAO().UpdateBill(id, gia, soluong);
            }
           
            return Json(new
            {

                status = dao,

            }, JsonRequestBehavior.AllowGet);
        }
        //get phieu nhat
        public ActionResult PhieuNhap(int stt=0)
        {
            var listmodel = new NhapHangDAO().GetPhieuNhap(stt);
            return View(listmodel);
        }
        public JsonResult GetNhap(int id)
        {
         
            var dao = new NhapHangDAO();
            var model = dao.GetNhapHangById(id);
           
            return Json(new
            {
                list = model,
                status = true,

            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult HoaDonNhap(string list)
        {
            var listnhap = new List<ProductViewModel>();
            if (list != null)
            {

                var jsonBill = new JavaScriptSerializer().Deserialize<List<String>>(list);
                var dao = new SanPhamDAO();
                for (int i = 0; i < jsonBill.Count; i++)
                {
                    var model = dao.GetListProductNhap(int.Parse(jsonBill[i].ToString()));
                    listnhap.Add(model);
                }
            }

            //return RedirectToAction("HoaDonNhap", "NhapHang");


            return Json(new
            {
                list = listnhap,
                status = true,

            }, JsonRequestBehavior.AllowGet);
        }
       
        public void sortby(ref List<ProductViewModel>  list)
        {
            int i, j;
            for (i = 0; i < list.Count - 1; i++)
                for (j = list.Count - 1; j > i; j--)
                    if (list[j - 1].IdNCC > list[j].IdNCC) //nghịch thế
                    {
                        var tmp = list[j - 1];
                        list[j - 1] = list[j];
                        list[j] = tmp;
                    }
        }
        public int countncc(List<ProductViewModel> list)
        {
            sortby(ref list);

            var tmp = list[0];
            int dem = 1;
            for (int i=0;i<list.Count;i++)
            {
                if (tmp != list[i])
                {
                    dem++;
                    tmp = list[i];
                }
            }
                return dem;
        }
        //xuat phieu nhập
        public bool Export(long id)
        {
            bool kq = false;
           
            try
            {
                var app = new Application();
                Workbook workbook = app.Workbooks.Add(System.Reflection.Missing.Value);
                Worksheet worksheet = workbook.ActiveSheet;
                var list = new NhapHangDAO().GetNhapHangById(id);

                worksheet.Cells[1, 1] = "Số phiếu nhập";
                worksheet.Cells[1, 2] = id;

                worksheet.Cells[1, 4] = "Phiếu nhập Mobile Shop";



                worksheet.Cells[3, 1] = "STT";
                worksheet.Cells[3, 2] = "Tên sản phẩm";
           
                worksheet.Cells[3, 3] = "Nhà cung cấp";
                worksheet.Cells[3, 4] = "Số lượng";

                worksheet.Cells[3, 5] = "Đơn giá";

                int row = 4;
                foreach (var item in list)
                {
                    worksheet.Cells[row, 1] = row - 3;
                    worksheet.Cells[row, 2] = item.NameProduct;
                
                    worksheet.Cells[row, 3] = item.NameNCC;
                    worksheet.Cells[row, 4] = item.Quality;
                    worksheet.Cells[row, 5] = item.Price;
                    row++;
                }
                worksheet.Cells[row + 1, 1] = "Người nhân(Ký và ghi rõ họ tên)";
                worksheet.Cells[row + 1, 5] = "Ngày ... Tháng ... Năm ...";
                worksheet.Cells[row + 2, 5] = "Người bán hàng(Ký và ghi rõ họ tên)";
                workbook.SaveAs(@"C:\Users\Tu\Desktop\bandienthoai\bandienthoai\Data\PhieuNhap\PhieuNhap_" + id + ".xls");

                workbook.Close();
                Marshal.ReleaseComObject(workbook);
                app.Quit();
                Marshal.FinalReleaseComObject(app);

                kq = true;
            }
            catch
            {

            }
            return kq;
            //return Json(new { status = kq }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult InsertBill(string list)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<ProductViewModel>>(list);
            sortby(ref jsonCart);
            int i , k =0;
            var tmp = jsonCart[0];
            for ( i=0; i < countncc(jsonCart); i++)
            {
              
                var l = new List<ProductViewModel>();
                for (int j=k ; j < jsonCart.Count; j++)
                {
                    if (tmp.IdNCC == jsonCart[j].IdNCC)
                    {
                        l.Add(jsonCart[j]);
                    }
                    else
                    {
                        k = j;
                        tmp = jsonCart[j];
                        break;

                    }

                }

                var pn = new PHIEUNHAPHANG();
                pn.STATUS = 0;
               
                pn.CREATEDATE = DateTime.Now;
                var id = new NhapHangDAO().InsertNhap(pn);
                
                if (id>0)
                {
                    foreach (var item in l)
                    {


                        var model = new DetailNhapModel();
                        model.idNCC = item.IdNCC;
                        model.idNhap = id;
                        model.idProduct = item.Id;
                        model.SoLuong = item.SoLuong;
                        model.Price = item.Price;
                        var kq = new NhapHangDAO().InsertDetailNhap(model);
                    }
                    Export(id);
                }


              
            }
            return Json(new
            {
              
                status = true,

            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult QLNhaCungCap()
        {
            var dao = new NhapHangDAO();
            var model = dao.listNhaCungCap();
            return View(model);
        }
        [HttpGet]
        public JsonResult QLPhieuNhapHang()
        {
            var dao = new NhapHangDAO();
            var model = dao.listPhieuNhapHang();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPhieuNhapHang(int id)
        {
            var dao = new NhapHangDAO();
            var pn = dao.listPhieuNhapHang().Find(x => x.PHIEUNHAPHANG_ID.Equals(x));
            return Json(pn, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CreatePhieuNhap(PHIEUNHAPHANG entity)
        {
            var dao = new NhapHangDAO();
            var pn = dao.InsertPhieuNhapHang(entity);
            return Json(new { msg = pn }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult CreateNCC()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreatePhieuNhapHang()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateNCC(NHACUNGCAP ncc)
        {
            if (ModelState.IsValid)
            {

                var dao = new NhapHangDAO();
                decimal id = dao.InsertNCC(ncc);
                if (id > 0)
                {
                    SetAlert("Thêm Thành công", "success");
                    return RedirectToAction("QLNhaCungCap", "NhapHang");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công!");
                    SetAlert("Thêm Thành công", "warning");
                }
            }
            return View("QLNhaCungCap");

        }

        [HttpGet]
        public ActionResult EditNCC(int id)
        {
            var user = new NhapHangDAO().ViewDetail(id);

            return View(user);
        }
        [HttpGet]
        public ActionResult EditPhieuNhapHang(int id)
        {
            var user = new NhapHangDAO().ViewDetail_PhieuNhapHang(id);

            return View(user);
        }
        [HttpPost]
        public ActionResult EditNCC(NHACUNGCAP ncc)
        {
            if (ModelState.IsValid)
            {
                var dao = new NhapHangDAO();

                var id = dao.UpdateNCC(ncc);
                if (id)
                {
                    SetAlert("Sửa thành công", "success");
                    return RedirectToAction("QLNhaCungCap", "NhapHang");
                }
                else
                {
                    SetAlert("Sửa không thành công", "warning");
                    ModelState.AddModelError("", "Cập nhật không thành Công!");
                }
            }
            return View("QLNhaCungCap");
        }
        [HttpPost]
        public ActionResult EditPhieuNhapHang(PHIEUNHAPHANG pn)
        {
            if (ModelState.IsValid)
            {
                var dao = new NhapHangDAO();

                //var id = dao.UpdatePhieuNhapHang(pn);
                //if (id)
                //{
                //    SetAlert("Sửa thành công", "success");
                //    return RedirectToAction("QLPhieuNhapHang", "NhapHang");
                //}
                //else
                //{
                //    SetAlert("Sửa không thành công", "warning");
                //    ModelState.AddModelError("", "Cập nhật không thành Công!");
                //}
            }
            return View("QLPhieuNhapHang");

        }
        [HttpDelete]
        public ActionResult DeleteNCC(int id)
        {
            new NhapHangDAO().DeleteNhaCungCap(id);
            SetAlert("Sửa không thành công", "warning");
            return RedirectToAction("QLNhaCungCap");
        }
        [HttpDelete]
        public ActionResult DeletePhieuNhapHang(int id)
        {
            new NhapHangDAO().DeletePhieuNhapHang(id);
            SetAlert("Sửa không thành công", "warning");
            return RedirectToAction("QLPhieuNhapHang");
        }
    }
}