using bandienthoai.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bandienthoai.Models.DAO
{
    public class OrderDetailDAO
    {
        QlBanHangDbContext db = null;
        public OrderDetailDAO()
        {
            db = new QlBanHangDbContext();
        }
        public bool Insert(ORDERDETAIL detail)
        {
            try {
                db.ORDERDETAILs.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch (Exception E)
            {
                return false;
            }
        }
    }
}