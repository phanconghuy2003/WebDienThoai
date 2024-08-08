using bandienthoai.Areas.Admin.Models;
using bandienthoai.Areas.Admin.Models.DAO;
using bandienthoai.Areas.Admin.Models.EF;
using bandienthoai.Common;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace bandienthoai.Areas.Admin.Controllers
{
    public class DonHangController : BaseController
    {
        // GET: Admin/DonHang
        [HasCredential(RoleID = "VIEW_ODER")]
        public ActionResult Index()
        {
            var dao = new DonHangDAO();
            var model = dao.GetListDonHang();
            return View(model);
        }
        public JsonResult Export(int id)
        {
            bool kq = false;
            try
            {
                var app = new Microsoft.Office.Interop.Excel.Application();
            Workbook workbook = app.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet worksheet = workbook.ActiveSheet;
            var oder = new DonHangDAO().GetDetailDonHang(id);

                worksheet.Cells[1, 1] = "Số hóa đơn";
                worksheet.Cells[1, 2] = id;

                worksheet.Cells[1, 4] = "Hóa đơn Mobile Shop";



                worksheet.Cells[3, 1] = "STT";
                worksheet.Cells[3, 2] = "Tên hàng hóa";
                worksheet.Cells[3, 3] = "ĐVT";
                worksheet.Cells[3, 4] = "Số lượng";
                worksheet.Cells[3, 5] = "Đơn giá";
                worksheet.Cells[3, 6] = "Giảm giá";
                worksheet.Cells[3, 7] = "Thành tiền";

           
                int row = 4;
            foreach (var item in oder)
            {
                worksheet.Cells[row, 1] = row-3;
                worksheet.Cells[row, 2] = item.NameProduct;
                worksheet.Cells[row, 3] = "VNĐ";
                worksheet.Cells[row, 4] = item.Quantity;
                worksheet.Cells[row, 5] = item.Quantity * item.Price;
                worksheet.Cells[row, 6] = item.Promotion;
                worksheet.Cells[row, 7] = item.Quantity * item.Price - (item.Quantity * item.Price)*(item.Promotion/100);
                    row++;
                }
                worksheet.Cells[row+1, 1] = "Người nhân(Ký và ghi rõ họ tên)";
                worksheet.Cells[row+2, 5] = "Ngày ... Tháng ... Năm ...";
                worksheet.Cells[row+1, 5] = "Người bán hàng(Ký và ghi rõ họ tên)";
                workbook.SaveAs(@"C:\Users\Tu\Desktop\bandienthoai\bandienthoai\Data\Content\HoaDon_" + id+ ".xls");
          
            workbook.Close();
            Marshal.ReleaseComObject(workbook);
            app.Quit();
            Marshal.FinalReleaseComObject(app);
            
                kq = true;
            }
            catch
            {

            }
            return Json(new { status=kq},JsonRequestBehavior.AllowGet) ;
        }
        public JsonResult DetailOrder(int id)
        {
            var dao = new DonHangDAO();
          
            List<OrderDetailModel> model = new List<OrderDetailModel>();
            model = dao.GetDetailDonHang(id);
            return Json( model,JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetListDonHang()
        {
            var dao = new DonHangDAO();
            var result = dao.GetListDonHang();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
      
        // set chờ duyệt
        public int changeChoDuyet(int id)
        {
            var user = ((UserLogin)Session[CommonStants.USER_SESSION]).userName;

            var dao = new DonHangDAO();
            var check = dao.GetOrderByID(id);
            if (check.STATUS == 2)
            {
                return dao.ChangeStatus(id, user, 1);
            }

            else
                return -1;
          
        }
        public int changeDaDuyet(int id)
        {
            var user = ((UserLogin)Session[CommonStants.USER_SESSION]).userName;
            var dao = new DonHangDAO();
            return dao.ChangeStatus(id, user, 2);

        }
      
        public int changeGiaoHang(int id)
        {
            var user = ((UserLogin)Session[CommonStants.USER_SESSION]).userName;
            var dao = new DonHangDAO();
            return dao.ChangeStatus(id, user, 6);
        }
        [HasCredential(RoleID = "DELETE_ODER")]
        public JsonResult Delete(int id)
        {
            var dao = new DonHangDAO();

            var result = false;


            result = dao.Delete(id);
            if (result)
            {
                SetAlert("Xóa thành công", "success");
            }
            else
            {
                ModelState.AddModelError("", "Xóa Thất Bại!");
            }

            return Json(result, JsonRequestBehavior.AllowGet);

        }
        public JsonResult ThanhToan(int id)
        {
            var dao = new DonHangDAO();

            var result = false;


            result = dao.ThanhToan(id,true);
            if (result)
            {
                SetAlert("Thanh toán thành công", "success");
            }
            else
            {
                ModelState.AddModelError("", "Thanh toán Thất Bại!");
            }

            return Json(result, JsonRequestBehavior.AllowGet);

        }
        public JsonResult ChuaThanhToan(int id)
        {
            var dao = new DonHangDAO();

            var result = false;


        dao.ThanhToan(id, false);
       

            return Json(result, JsonRequestBehavior.AllowGet);

        }
    }
}