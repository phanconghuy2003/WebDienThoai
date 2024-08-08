using bandienthoai.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bandienthoai.Models.DAO
{
    public class OrderDAO
    {
        QlBanHangDbContext db = null;
        public OrderDAO()
        {
            db = new QlBanHangDbContext();
        }
        //kiem tra don hang tai xe
        public SHIPPER checkOrder(string user)
        {
            var model = db.SHIPPERs.SingleOrDefault(x=>x.IS_DELETE == false && x.USERNAME==user);
            return model;
            //try
            //{
            //    var Order = (from a in db.ORDERs
            //             join b in db.SHIPPERs
            //             on a.ID equals b.ORDERID
            //             where a.STATUS == 5
            //             select a).ToList();
           
            //    if (Order!=null)
            //{


            //    return Order[0].ID;
            //}
            //}
            //catch
            //{
            //    return -1;
            //}
            //return -1;
        }
        public bool UpdateOrder(int id,int status)
        {
            var Order = db.ORDERs.Find(id);
          
            if (Order != null)
            {
 
                Order.STATUS = status;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public long Insert(ORDER order)
        {
            db.ORDERs.Add(order);
            db.SaveChanges();
            return order.ID;
        }
        public ORDER GetOderbyID(long id)
        {
           return db.ORDERs.Find(id);
          
        }
        public List<ShipperDetailOrderModel> GetDetailOderbyID(long id)
        {
            var kq = (from a in db.SANPHAMs
                      join b in db.ORDERDETAILs
                      on a.SANPHAM_ID equals b.PRODUCTID
                      where b.ORDERID==id
                      select new
                      {

                          IDProduct = a.SANPHAM_ID,
                          NameProduct = a.TEN_SANPHAM,
                     
                          Price = b.PRICE,
                         soluong=b.QUANTITY

                      }).AsEnumerable().Select(x => new ShipperDetailOrderModel
                      {

                          IDProduct = x.IDProduct,
                          NameProduct = x.NameProduct,
                 
                          Price = x.Price,
                          Soluong = (int)x.soluong
                      }).ToList();
            return kq;

        }

        public bool InsertShipper(SHIPPER s)
        {
            if (s!=null){
                var sp = new SHIPPER();
                sp.USERNAME = s.USERNAME;
                sp.ORDERID = s.ORDERID;
                db.SHIPPERs.Add(sp);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}