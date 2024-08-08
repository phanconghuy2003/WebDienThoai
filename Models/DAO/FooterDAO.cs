using bandienthoai.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bandienthoai.Models.DAO
{
    public class FooterDAO
    {
        QlBanHangDbContext db = null;
        public FooterDAO()
        {
            db = new QlBanHangDbContext();
        }
        public FOOTER GetFooter()
        {
            var kq = new FOOTER();
                kq=db.FOOTERs.SingleOrDefault(x => x.IS_DELETE == false);
           
            return kq;
        }
    }
}