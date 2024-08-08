using bandienthoai.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bandienthoai.Models.DAO
{
    public class RecommenderDAO
    {
        QlBanHangDbContext db = null;
        public RecommenderDAO()
        {
            db = new QlBanHangDbContext();
        }
        public bool insert(long i,long j)
        {
            RECOMMENDER chek = db.RECOMMENDERs.Find(i,j);
            try
            {
                if (chek == null)
                {

                    var model = new RECOMMENDER();
                    model.IDPRODUCT1 = i;
                    model.IDPRODUCT2 = j;
                    model.QUANLITY = 1;
                    model.CREATEDATE = DateTime.Now;
                    db.RECOMMENDERs.Add(model);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    chek.QUANLITY += 1;
                    chek.MODIFILEDDATE = DateTime.Now;
                    
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
           
        }
    }
}