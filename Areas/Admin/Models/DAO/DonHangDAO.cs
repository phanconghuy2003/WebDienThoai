using bandienthoai.Areas.Admin.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bandienthoai.Areas.Admin.Models.DAO
{
    public class DonHangDAO
    {
        QlBanHangDbContext db = null;
        public DonHangDAO()
        {
            db = new QlBanHangDbContext();
        }
        public ORDER GetOrderByID(int id)
        {
           
            return db.ORDERs.Find(id);
        }
        //get list dơn hàng

        public List<ORDER> GetListDonHang()
        {
            var model = db.ORDERs.OrderByDescending(t => t.CREATEDATE).ToList();
            return model;
        }
        public List<DonHangModel> GetDonHangbyid(int id)
        {
            var model = (
                        from b in db.ORDERDETAILs
                        join a in db.ORDERs
                        on b.ORDERID equals a.ID
                        join c in db.SANPHAMs
                        on b.PRODUCTID equals c.SANPHAM_ID
                        where b.ORDERID == id
                        select new
                        {
                           
                            Quantity = b.QUANTITY,
                            Price = b.PRICE,
                            Name= a.SHIPNAME,
                            SDT=a.SHIPMOBILE,
                            Email=a.SHIPEMAIL,
                                            
                            NameProduct = c.TEN_SANPHAM,



                        }).AsEnumerable().Select(t => new DonHangModel
                        {

                            SOLUONG = (int)t.Quantity,
                            DONGIA = t.Price,
                            HOTEN = t.Name,
                            SDT = t.SDT,
                            GMAIL = t.Email,
                          
                            TENSANPHAM = t.NameProduct,

                        }).ToList();
            return model;
        }
        //get detail dơn hàng
        public List<OrderDetailModel> GetDetailDonHang(int id)
        {
            var model =(
                        from b in db.ORDERDETAILs
                       
                        join c in db.SANPHAMs
                        on b.PRODUCTID equals c.SANPHAM_ID
                        where b.ORDERID==id
                        select new
                        {
                            OrderId= b.ORDERID,
                            Quantity=b.QUANTITY,
                            Price=b.PRICE,
                           
                            NameProduct=c.TEN_SANPHAM,
                          
                         

                        }).AsEnumerable().Select(t=>new OrderDetailModel{
                            OrderId = (long)t.OrderId,
                            Quantity = (int)t.Quantity,
                            Price = t.Price,
                          
                            NameProduct = t.NameProduct,
                         
                        }).ToList();
            return model;
        }

        public int ChangeStatus(int id, string name, int stt)
        {

            try
            {
                var kq = db.ORDERs.Find(id);
                kq.STATUS = stt;
         

                db.SaveChanges();
                return stt;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public bool ThanhToan(decimal id,bool stt)
        {
            try
            {
                var MODEL = db.ORDERs.Find(id);
                MODEL.IS_DELETE = stt;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool Delete(decimal id)
        {
            try
            {
                var MODEL = db.ORDERs.Find(id);
                db.ORDERs.Remove(MODEL);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}