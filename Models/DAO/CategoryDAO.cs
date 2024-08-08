
using bandienthoai.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bandienthoai.Models.DAO
{
    public class CategoryDAO
    {
        QlBanHangDbContext db = null;
        public CategoryDAO()
        {
            db = new QlBanHangDbContext();
        }
        public List<LOAISANPHAM> ListAll()
        {
            return db.LOAISANPHAMs.Where(x => x.IS_DELETE == false).OrderBy(y => y.CREATDATE).ToList();
        }
        public LOAISANPHAM ViewDetail(decimal id)
        {
            return db.LOAISANPHAMs.Find(id);
        }
    }
}