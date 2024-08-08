using bandienthoai.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bandienthoai.Models.DAO
{
    public class ContactDAO
    {
        QlBanHangDbContext db = null;
        public  ContactDAO()
        {
            db = new QlBanHangDbContext();
        }
        public CONTACT getContact()
        {
            return db.CONTACTs.Single(t=>t.STATUS==true);
        }
        public int InsertFeedBack(FEEDBACK fb)
        {
            db.FEEDBACKs.Add(fb);
            db.SaveChanges();

            return fb.ID;
        }
    }
}