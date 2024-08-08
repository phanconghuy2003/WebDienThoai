using bandienthoai.Areas.Admin.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bandienthoai.Areas.Admin.Models.DAO
{
    public class BannerDAO
    {
        QlBanHangDbContext db = null;
        public BannerDAO()
        {
            db = new QlBanHangDbContext();
        }
        public bool Delete(int id)
        {
            try
            {
                var MODEL = db.SLIDEs.Find(id);
                db.SLIDEs.Remove(MODEL);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public List<BannerModel> GetListBanner()
        {
        
            var kq = db.BANNERs.Select(t => new BannerModel
            {
                BANNER_ID = t.BANNER_ID,
                LINK = t.LINK,
                GHICHU_BANNER = t.GHICHU_BANNER,
                VITRI = t.VITRI,
                HINH = t.HINH,
                TIEUDE = t.TIEUDE,
           
                IS_DELETE = t.IS_DELETE,
                CREATEBY = t.CREATEBY,
                MODIFILEDBY = t.MODIFILEDBY,
                MODIFILEDDATE = t.MODIFILEDDATE,
                CREATEDATE = t.CREATEDATE,


            }).ToList();
            return kq;
        }

        public string GetsrcLogo(int v)
        {
            try
            { 
            return db.SLIDEs.SingleOrDefault(x => x.STATUS == v).IMAGE;
            }
            catch
            {
                return null;
            }
        }

        public List<SLIDE> GetListSlide(int stt)
        {
           
            try
            {
                return db.SLIDEs.Where(x => x.STATUS == stt).ToList();
            }
            catch
            {
                return null;
            }
        }
        public SLIDE GetLogo()
        {
            try
            {
                return db.SLIDEs.SingleOrDefault(x => x.STATUS == 0);
            }
            catch
            {
                return null;
            }
        }
        public void UpdateLogo(SLIDE sp)
        {
            SLIDE model = GetLogo();
            model.IMAGE = sp.IMAGE;
            db.SaveChanges();
        }

        //lưu dữ liệu
        public int SaveData(BannerModel x, string user)
        {
            try
            {
                if (x.BANNER_ID > 0)
                {

                    BANNER dao = db.BANNERs.SingleOrDefault(m => m.BANNER_ID == x.BANNER_ID);
                    dao.HINH = x.HINH;
                    dao.IS_DELETE = false;
                    dao.MODIFILEDDATE = DateTime.Now.Date;
                    dao.MODIFILEDBY = user;
                    dao.LINK = x.LINK;
                    dao.GHICHU_BANNER = x.GHICHU_BANNER;
                
                    dao.TIEUDE = x.TIEUDE;
                    dao.VITRI = x.VITRI;
                    db.SaveChanges();

                    return 1;

                }
                else
                {
                    BANNER dao = new BANNER();

                    dao.HINH = x.HINH;
                    dao.IS_DELETE = false;
                    dao.MODIFILEDDATE = DateTime.Now.Date;
                    dao.MODIFILEDBY = user;
                    dao.CREATEBY = x.CREATEBY;
                    dao.TIEUDE = x.TIEUDE;
                    dao.VITRI = x.VITRI;
                    dao.LINK = x.LINK;
                    dao.GHICHU_BANNER = x.GHICHU_BANNER;

                    dao.CREATEDATE = DateTime.Now.Date;
                    dao.CREATEBY = user;

                    db.BANNERs.Add(dao);
                    db.SaveChanges();

                    return 2;
                }

            }
            catch
            {
                return 0;
            }

        }
        public int SaveSlide(SLIDE x,string user)
        {
            try
            {
                if (x.ID > 0)
                {

                    SLIDE dao = db.SLIDEs.SingleOrDefault(m => m.ID == x.ID);
                    dao.IMAGE = x.IMAGE;
                    dao.IS_DELETE = false;
                    dao.MODIFILEDDATE = DateTime.Now.Date;
                    dao.MODIFILEDBY = user;
                    dao.LINK = x.LINK;
                    dao.GHICHU = x.GHICHU;
                    dao.STATUS = x.STATUS;
                  
                 
                    db.SaveChanges();

                    return 1;

                }
                else
                {
                    SLIDE dao = new SLIDE();

                    dao.IMAGE = x.IMAGE;
                    dao.IS_DELETE = false;
                    dao.MODIFILEDDATE = DateTime.Now.Date;
                    dao.MODIFILEDBY = user;
                    dao.CREATEBY = x.CREATEBY;
                   
                    dao.LINK = x.LINK;
                    dao.GHICHU = x.GHICHU;
                    dao.STATUS = x.STATUS;

                    dao.CREATEDATE = DateTime.Now.Date;
                    dao.CREATEBY = user;

                    db.SLIDEs.Add(dao);
                    db.SaveChanges();

                    return 2;
                }

            }
            catch
            {
                return 0;
            }

        }

    }
}