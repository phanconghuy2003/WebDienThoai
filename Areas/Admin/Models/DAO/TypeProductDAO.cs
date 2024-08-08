using bandienthoai.Areas.Admin.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bandienthoai.Areas.Admin.Models.DAO
{
    public class TypeProductDAO
    {
        QlBanHangDbContext db = null;
        public TypeProductDAO()
        {
            db = new QlBanHangDbContext();
        }
        public List<LOAISANPHAM> GetListProduct()
        {
            return db.LOAISANPHAMs.ToList();
        }
        public LOAISANPHAM GetTypeProductByID(long id)
        {
            return db.LOAISANPHAMs.Find(id);
        }
        public LOAISANPHAM GetByTitle(string tieude)
        {
            try { 
            return db.LOAISANPHAMs.SingleOrDefault(t => t.TEN_LOAISANPHAM == tieude);
            }
            catch
            {
                return null;
            }
        }
        public decimal Insert(LOAISANPHAM tt)
        {
            tt.DISPLAYORDER = db.LOAISANPHAMs.Count();
            db.LOAISANPHAMs.Add(tt);
            db.SaveChanges();
            return tt.LOAISANPHAM_ID;

        }
        public bool Update(LOAISANPHAM tt)
        {
            var model = db.LOAISANPHAMs.Find(tt.LOAISANPHAM_ID);
            model.TEN_LOAISANPHAM = tt.TEN_LOAISANPHAM;
            if (model.LOAISANPHAM_ID != tt.PARENTID)
            {
                model.PARENTID = tt.PARENTID;
            }
           
            model.GHICHU_LOAISANPHAM = tt.GHICHU_LOAISANPHAM;
          
            db.SaveChanges();
            return true;

        }
        public bool Delete(decimal id)
        {
           var kq= (db.SANPHAMs.Where(x => x.LOAISANPHAM_ID == id).ToList()).Count;
            if(kq>0)
                return false;

            try
            {
                var MODEL = db.LOAISANPHAMs.Find(id);
                db.LOAISANPHAMs.Remove(MODEL);
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