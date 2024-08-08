using bandienthoai.Areas.Admin.Models.EF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bandienthoai.Areas.Admin.Models.DAO
{
    public class NhaSanXuatDAO
    {
        QlBanHangDbContext db = null;
        public NhaSanXuatDAO()
        {
            db = new QlBanHangDbContext();
        }
        public List<NhaSanXuatModel> GetListNhaSX()
        {
            var kq = db.NHASANXUATs.Select(t => new NhaSanXuatModel
            {
                ID_NSX = t.ID_NSX,
                MANSX = t.MANSX,
                TEN_NSX = t.TEN_NSX,
                SDT_NSX = t.SDT_NSX,
                MOTA_NSX = t.MOTA_NSX,
                DIACHI_NSX = t.DIACHI_NSX,
                GHICHU_NSX = t.GHICHU_NSX,
                IS_DELETE = t.IS_DELETE,
                CREATEBY = t.CREATEBY,
                MODIFILEDBY = t.MODIFILEDBY,
                MODIFILEDDATE = t.MODIFILEDDATE,
                CREATEDATE = t.CREATEDATE,


            }).ToList();
            return kq;
        }
        public List<NHASANXUAT> getAllNSX()
        {
            return db.NHASANXUATs.ToList();
        }
        //public string GetListNSXByID(int id)
        //{
        //    var kq = db.NHASANXUATs.Where(x=>x.ID_NSX==id).Select(t => new NhaSanXuatModel
        //    {
        //        ID_NSX = t.ID_NSX,
        //        MANSX = t.MANSX,
        //        TEN_NSX = t.TEN_NSX,
        //        SDT_NSX = t.SDT_NSX,
        //        MOTA_NSX = t.MOTA_NSX,
        //        DIACHI_NSX = t.DIACHI_NSX,
        //        GHICHU_NSX = t.GHICHU_NSX,
        //        IS_DELETE = t.IS_DELETE,
        //        CREATEBY = t.CREATEBY,
        //        MODIFILEDBY = t.MODIFILEDBY,
        //        MODIFILEDDATE = t.MODIFILEDDATE,
        //        CREATEDATE = t.CREATEDATE,


        //    }).ToList();
        //    string value = string.Empty;
        //    value = JsonConvert.SerializeObject(kq, Formatting.Indented, new JsonSerializerSettings
        //    {
        //        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        //    });
        //    return value;
        //}
        public string GetListNSXByID(long ID)
        {
            var model = db.NHASANXUATs.Where(x => x.ID_NSX == ID).SingleOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return value;
        }
        //delete
        public bool Delete(int id)
        {
            try
            {
                var t = db.NHASANXUATs.Find(id);
                db.NHASANXUATs.Remove(t);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        //get  nsx by id
        public NHASANXUAT GetById(int id)
        {
            try { return db.NHASANXUATs.SingleOrDefault(t => t.ID_NSX == id); }
            catch
            {
                return null;
            }
        }
        // ẩn hiện
        public int ChangeStatus(int id, string name, bool kq)
        {
            int i = 0;
            try
            {
                var user = db.NHASANXUATs.Find(id);
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
        //lưu dữ liệu
        public int SaveData(NhaSanXuatModel x, string user)
        {
            try
            {
                if (x.ID_NSX > 0)
                {


                    NHASANXUAT dao = db.NHASANXUATs.SingleOrDefault(m => m.ID_NSX == x.ID_NSX);
                    dao.TEN_NSX = x.TEN_NSX;
                    dao.IS_DELETE = false;
                    dao.MODIFILEDDATE = DateTime.Now.Date;
                    dao.MODIFILEDBY = user;
                    dao.MOTA_NSX = x.MOTA_NSX;
                    dao.DIACHI_NSX = x.DIACHI_NSX;
                    dao.MANSX = x.MANSX;
                    dao.SDT_NSX = x.SDT_NSX;
                    dao.GHICHU_NSX = x.GHICHU_NSX;
                    db.SaveChanges();

                    return 1;

                }
                else
                {
                    NHASANXUAT dao = new NHASANXUAT();

                    dao.TEN_NSX = x.TEN_NSX;
                    dao.IS_DELETE = false;
                    dao.MODIFILEDDATE = DateTime.Now.Date;
                    dao.MODIFILEDBY = user;
                    dao.MOTA_NSX = x.MOTA_NSX;
                    dao.DIACHI_NSX = x.DIACHI_NSX;
                    dao.MANSX = x.MANSX;
                    dao.SDT_NSX = x.SDT_NSX;
                    dao.GHICHU_NSX = x.GHICHU_NSX;

                    dao.CREATEDATE = DateTime.Now.Date;
                    dao.CREATEBY = user;

                    db.NHASANXUATs.Add(dao);
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