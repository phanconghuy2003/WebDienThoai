using bandienthoai.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bandienthoai.Models.DAO
{
    public class ShipperDAO
    {
        QlBanHangDbContext db = null;
        public ShipperDAO()
        {
            db = new QlBanHangDbContext();
        }
       public List<ORDER> GetListOrder(int st ,string key=null)
        {
            return db.ORDERs.Where(x => x.STATUS == st).ToList();
        }
        public bool Dagiao(string user)
        {
            var model = db.SHIPPERs.SingleOrDefault(x => x.USERNAME == user && x.IS_DELETE == false);
            model.IS_DELETE = true;
            db.SaveChanges();
            return true;
        }
        public ORDER GetDetailOrderbyID(int id)
        {
            return db.ORDERs.Find(id);
        }
        public int getshipper(string user)
        {
            try
            {
                return db.SHIPPERs.SingleOrDefault(x => x.USERNAME == user&& x.IS_DELETE==false).ORDERID;
            }
            catch
            {
                return -1;
            }
        }
    }
}