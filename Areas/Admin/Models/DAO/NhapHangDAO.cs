using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bandienthoai.Areas.Admin.Models.EF;
using bandienthoai.Common;
using PagedList;

namespace bandienthoai.Areas.Admin.Models.DAO
{
    public class NhapHangDAO
    {
        QlBanHangDbContext db = null;
        //Khởi tạo tham số
        public NhapHangDAO()
        {
            db = new QlBanHangDbContext();
        }
      public List<PHIEUNHAPHANG> GetPhieuNhap(int stt)
        {
            return db.PHIEUNHAPHANGs.Where(t => t.STATUS == stt).ToList();
        }
        public decimal InsertNCC(NHACUNGCAP ncc)
        {
            db.NHACUNGCAPs.Add(ncc);
            db.SaveChanges();
            return ncc.ID_NCC;
        }
        public decimal InsertPhieuNhapHang(PHIEUNHAPHANG pn)
        {
            db.PHIEUNHAPHANGs.Add(pn);
            db.SaveChanges();
            return pn.PHIEUNHAPHANG_ID;
        }

        public bool UpdateBill(int id, int? gia = null, int? soluong = null)
        {
            var kq = false;
            var model = db.PHIEUNHAPHANGs.Find(id);
            model.STATUS = 1;
            db.SaveChanges();
            var list = db.PHIEUNHAPKHOes.Where(x => x.IDNHAPHANG == id).ToList();
            foreach (var item in list)
            {
                SANPHAM sp = db.SANPHAMs.Find(item.IDSANPHAM);
                if (gia!=null)
                {
                    sp.GIANHAP += gia;
                }
         else
                sp.GIANHAP = item.DONGIA;

                if (soluong != null)
                {
                    sp.SOLUONGTON += soluong;
                }
                else
                    sp.SOLUONGTON += item.SOLUONG;
                db.SaveChanges();
                kq = true;
            }
            return kq;
        }

        public bool Delete(int id)
        {
            var kq = false;
            try
            {
                DeleteDetail(id);
                var model = db.PHIEUNHAPHANGs.Find(id);
                db.PHIEUNHAPHANGs.Remove(model);
                db.SaveChanges();
                kq = true;
            }
            catch
            {
                kq = false;
            }
            return kq;
        }
        public void DeleteDetail(int id)
        {
            
            var list = db.PHIEUNHAPKHOes.Where(x => x.IDNHAPHANG == id).ToList();
            foreach (var item in list)
            {
                db.PHIEUNHAPKHOes.Remove(item);
            }
            db.SaveChanges();
           
        }
        public int? GetStatus(int id)
        {
           return db.PHIEUNHAPHANGs.Find(id).STATUS;
        }

        public bool UpdateNCC(NHACUNGCAP ncc)
        {
            try
            {
                var nhacc = db.NHACUNGCAPs.Find(ncc.ID_NCC);
                nhacc.TEN_NCC = ncc.TEN_NCC;
                nhacc.DIACHI_NCC = ncc.DIACHI_NCC;
                nhacc.EMAIL_NCC = ncc.EMAIL_NCC;
                nhacc.SDT_NCC = ncc.SDT_NCC;
                nhacc.IS_DELETE = ncc.IS_DELETE;
                nhacc.MODIFILEDBY = ncc.MODIFILEDBY;
                nhacc.MODIFILEDDATE = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public long InsertNhap(PHIEUNHAPHANG pn)
        {
            try
            {
                var id = db.CHITIETPHIEUNHAPHANGs.Count();
                pn.TENPHIEUNHAP = "Phiếu nhập_" + id;
                var kq = db.PHIEUNHAPHANGs.Add(pn);
                db.SaveChanges();
                return pn.PHIEUNHAPHANG_ID;
            }
            catch
            {
                return -1;
            }
            
        }
        public List<PhieuNhapModel> GetNhapHangById(long id)
        {
            
                var kq = (from a in db.SANPHAMs
                          join b in db.PHIEUNHAPKHOes
                          on a.SANPHAM_ID equals b.IDSANPHAM
                          join c in db.NHACUNGCAPs
                          on b.IDNCC equals c.ID_NCC
                          where b.IDNHAPHANG == id


                          select new
                          {
                              NameProduct = a.TEN_SANPHAM,
                              NameNCC = c.TEN_NCC,
                              Quality = b.SOLUONG,
                              Price = b.DONGIA
                          }).AsEnumerable().Select(x => new PhieuNhapModel()
                          {
                              NameProduct = x.NameProduct,
                              NameNCC = x.NameNCC,
                              Quality = x.Quality,
                              Price = x.Price

                          }).ToList();
            return kq;
           
        }

        //public bool UpdatePhieuNhapHang(PHIEUNHAPHANG pn)
        //{
        //    try
        //    {
        //        var phieunhap = db.PHIEUNHAPHANGs.Find(pn.PHIEUNHAPHANG_ID);
        //        phieunhap.SOPHIEUNHAPHANG = pn.SOPHIEUNHAPHANG;
        //        phieunhap.MA_NCC = pn.MA_NCC;
        //        phieunhap.NGUOIGIAO = pn.NGUOIGIAO;
        //        phieunhap.NGAYGIAO = pn.NGAYGIAO;
        //        phieunhap.TRANGTHAINHAPHANG = pn.TRANGTHAINHAPHANG;
        //        phieunhap.MODIFILEDBY = pn.MODIFILEDBY;
        //        phieunhap.MODIFILEDDATE = DateTime.Now;
        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}
        public bool DeleteNhaCungCap(int id)
        {
            try
            {
                var ncc = db.NHACUNGCAPs.Find(id);
                db.NHACUNGCAPs.Remove(ncc);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public long InsertDetailNhap(DetailNhapModel model)
        {
            var nhap = new PHIEUNHAPKHO();
            nhap.IDNCC = model.idNCC;
            nhap.IDSANPHAM = model.idProduct;
            nhap.SOLUONG = model.SoLuong;
            nhap.IDNHAPHANG = model.idNhap;
            nhap.CREATEDATE = DateTime.Now;
            db.PHIEUNHAPKHOes.Add(nhap);
            db.SaveChanges();
            if (nhap.PHIEUNHAPKHO_ID> 0) { return nhap.PHIEUNHAPKHO_ID; }
            return -1;
        }

        public bool DeletePhieuNhapHang(int id)
        {
            try
            {
                var pn = db.PHIEUNHAPHANGs.Find(id);
                db.PHIEUNHAPHANGs.Remove(pn);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public List<NHACUNGCAP> listNhaCungCap()
        {
            return db.NHACUNGCAPs.ToList();
        }
        public List<PHIEUNHAPHANG> listPhieuNhapHang()
        {
            return db.PHIEUNHAPHANGs.ToList();
        }
        public NHACUNGCAP ViewDetail(int id)
        {
            return db.NHACUNGCAPs.Find(id);
        }
        public PHIEUNHAPHANG ViewDetail_PhieuNhapHang(int id)
        {
            return db.PHIEUNHAPHANGs.Find(id);
        }
    }
}