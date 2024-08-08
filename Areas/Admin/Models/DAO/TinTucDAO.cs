using bandienthoai.Areas.Admin.Models.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace bandienthoai.Areas.Admin.Models.DAO
{
    public class TinTucDAO
    {
        QlBanHangDbContext db = null;
        public TinTucDAO()
        {
            db = new QlBanHangDbContext();
        }
        public decimal Insert(TinTucModel x)
        {

            try
            {




                TINTUC dao = new TINTUC();
                dao.IS_DELETE = false;
              
                dao.IDTAIKHOAN = x.IDTAIKHOAN;
                dao.TIEUDE_TINTUC = x.TIEUDE_TINTUC;
                dao.GHICHU_TINTUC = x.GHICHU_TINTUC;
                dao.HINHANH_TINTUC = x.HINHANH_TINTUC;
                dao.MOTA_TINTUC = x.MOTA_TINTUC;
                dao.NOIDUNG = x.NOIDUNG;

                dao.CREATEDATE = x.CREATEDATE;
                dao.CREATEBY = x.CREATEBY;

                db.TINTUCs.Add(dao);
                db.SaveChanges();

                return dao.TINTUC_ID;


            }
            catch
            {
                return -1;
            }

        }

        public bool updatenoidung(string link,decimal id)
        {
            try
            {
                var user = db.TINTUCs.Find(id);
                user.NOIDUNG = link;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(TINTUC tt)
        {
            try
            {
                var user = db.TINTUCs.Find(tt.TINTUC_ID);
                user.TIEUDE_TINTUC = tt.TIEUDE_TINTUC;

                user.MOTA_TINTUC = tt.MOTA_TINTUC;
                user.NOIDUNG = tt.NOIDUNG;
                user.HINHANH_TINTUC = tt.HINHANH_TINTUC;
                user.GHICHU_TINTUC = tt.GHICHU_TINTUC;
                user.IS_DELETE = tt.IS_DELETE;
                user.MODIFILEDBY = tt.MODIFILEDBY;
                user.MODIFILEDDATE = DateTime.Now;

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public int ChangeStatus(int id, string name, bool kq)
        {
            int i = 0;
            try
            {
                var user = db.TINTUCs.Find(id);
                if (kq)
                {
                    user.IS_DELETE = true;
                    i = 1;
                }
                else
                { user.IS_DELETE = false; i = 2; }
                user.MODIFILEDBY = name;
                user.MODIFILEDDATE = DateTime.Now;

                db.SaveChanges();
                return i;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public decimal getIDLastNews()
        {
            try
            {
                List<TINTUC> result = db.TINTUCs.OrderBy(t => t.TINTUC_ID).Skip(db.TINTUCs.Count() - 1).Take(1).ToList();
                return result[0].TINTUC_ID;
            }

            catch (Exception ex)
            {
                return 0;
            }
        }
        public string GetByTitle(string tieude)
        {
            var kq = new TINTUC();
            try
            {
                kq = db.TINTUCs.SingleOrDefault(t => t.TIEUDE_TINTUC == tieude);
                if (kq != null)
                    return kq.TIEUDE_TINTUC;
            }
            catch
            {

            }
            return null;
        }
        //public long getIDLastChild()
        //{
        //    long kq = -1;
        //    try
        //    {

        //        var i = db.TINTUCs.Count();
        //        if (i > 0)
        //        {
        //            List<TINTUC> result = db.TINTUCs.OrderBy(t => t.TINTUC_ID).Skip(db.TINTUCs.Count() - 1).Take(1).ToList();
        //            kq = result[0].TINTUC_ID;
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        kq = -1;
        //    }
        //    return kq;
        //}
        public TINTUC GetById(long id)
        {
            return db.TINTUCs.SingleOrDefault(t => t.TINTUC_ID == id);
        }
        public List<TinTucModel> listTintuc()
        {
            var kq = db.TINTUCs.Select(t => new TinTucModel
            {
                IDTAIKHOAN = t.IDTAIKHOAN,
                TINTUC_ID = t.TINTUC_ID,
             
                TIEUDE_TINTUC = t.TIEUDE_TINTUC,
                MOTA_TINTUC = t.MOTA_TINTUC,
                NOIDUNG = t.NOIDUNG,
                HINHANH_TINTUC = t.HINHANH_TINTUC,
                GHICHU_TINTUC = t.GHICHU_TINTUC,
                IS_DELETE = t.IS_DELETE,
                CREATEBY = t.CREATEBY,
                CREATEDATE = t.CREATEDATE,
                MODIFILEDDATE = t.MODIFILEDDATE,
                MODIFILEDBY = t.MODIFILEDBY

            }).ToList();
            return kq;
        }

        public void DeleteFile(string fileName)
        {
            try
            {
                FileInfo fi;
                if (System.IO.File.Exists(fileName) == true)
                {
                    fi = new FileInfo(fileName);
                    fi.Delete();

                }
            }
            catch (Exception ex) { ex.Message.ToString(); }
        }
        public bool Delete(int id)
        {
            try
            {
                var t = db.TINTUCs.Find(id);
                db.TINTUCs.Remove(t);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool changeImage(long id, string picture)
        {
            try
            {
                var t = db.TINTUCs.Find(id);
                t.HINHANH_TINTUC = picture;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<TINTUC> getAllNews()
        {
            return db.TINTUCs.ToList();
        }
        public TINTUC GetByID(int id)
        {
            return db.TINTUCs.SingleOrDefault(x => x.TINTUC_ID == id);
        }
        public TINTUC ViewDetail(int id)
        {
            return db.TINTUCs.Find(id);
        }


    }
}