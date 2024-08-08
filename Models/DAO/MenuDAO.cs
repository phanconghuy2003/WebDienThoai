
using bandienthoai.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bandienthoai.Models.DAO
{
    public class MenuDAO
    {
            QlBanHangDbContext db = null;
            public MenuDAO()
            {
                db = new QlBanHangDbContext();
            }
        public List<Menu> ListByGroupId(int groupid)
        {
            return db.Menus.Where(t => t.TYPEID == groupid).ToList();
        }
    }
}