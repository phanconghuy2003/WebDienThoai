
using bandienthoai.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bandienthoai.Models.DAO
{
    public class BannerDAO
    {
        QlBanHangDbContext db = null;
        public BannerDAO()
        {
            db = new QlBanHangDbContext();
        }
        public List<SLIDE> GetListBanner(int index)
        {
            return db.SLIDEs.Where(x => x.STATUS == 1).OrderBy(y => y.DISPLAYORDER).ToList();
        
           
        }
        public SLIDE GetLogo(int vt)
        {
            var kq = new SLIDE();
           kq=  db.SLIDEs.SingleOrDefault(x => x.IS_DELETE == false && x.STATUS == vt);
            //if (kq == null)
            //    kq.HINH = "\\Data\\slides\\logo-mobile.png";
            return kq;


        }
        public List<BANNER> GetBanner(int index)
        {
            return db.BANNERs.Where(x => x.IS_DELETE == false&&x.VITRI==index).ToList();


        }
    }
}