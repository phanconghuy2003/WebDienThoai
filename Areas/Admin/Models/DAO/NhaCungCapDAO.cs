using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using bandienthoai.Areas.Admin.Models.EF;
using bandienthoai.Common;
using Newtonsoft.Json;
using PagedList;


namespace bandienthoai.Areas.Admin.Models.DAO
{
    public class NhaCungCapDAO
    {
        QlBanHangDbContext db = null;
        public NhaCungCapDAO()
        {
            db = new QlBanHangDbContext();
        }
        public List<NhaCungCapModel> getAllNCC()
        {
            var kq = db.NHACUNGCAPs.Select(t => new NhaCungCapModel
            {
                ID_NCC = t.ID_NCC,
                MANCC = t.MANCC,
                TEN_NCC = t.TEN_NCC,
                SDT_NCC = t.SDT_NCC,

                DIACHI_NCC = t.DIACHI_NCC,
                EMAIL_NCC = t.EMAIL_NCC,
                IS_DELETE = t.IS_DELETE,
                CREATEBY = t.CREATEBY,
                MODIFILEDBY = t.MODIFILEDBY,
                MODIFILEDDATE = t.MODIFILEDDATE,
                CREATEDATE = t.CREATEDATE,


            }).ToList();
            return kq;
        }
        public string GetListNCCByID(long ID)
        {
            var model = db.NHACUNGCAPs.Where(x => x.ID_NCC == ID).SingleOrDefault();
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
                var t = db.NHACUNGCAPs.Find(id);
                db.NHACUNGCAPs.Remove(t);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        //get  ncc by id
        public NHACUNGCAP GetById(int id)
        {


            try
            {
                var kq = db.NHACUNGCAPs.SingleOrDefault(t => t.ID_NCC == id);
                return kq;
            }
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
                var user = db.NHACUNGCAPs.Find(id);
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
        public int SaveData(NhaCungCapModel x, string user)
        {
            try
            {
                if (x.ID_NCC > 0)
                {


                    NHACUNGCAP dao = db.NHACUNGCAPs.SingleOrDefault(m => m.ID_NCC == x.ID_NCC);
                    dao.TEN_NCC = x.TEN_NCC;
                    dao.IS_DELETE = false;
                    dao.MODIFILEDDATE = DateTime.Now.Date;
                    dao.MODIFILEDBY = user;
                    dao.EMAIL_NCC = x.EMAIL_NCC;
                    dao.DIACHI_NCC = x.DIACHI_NCC;
                    dao.MANCC = x.MANCC;
                    dao.SDT_NCC = x.SDT_NCC;

                    db.SaveChanges();

                    return 1;

                }
                else
                {
                    NHACUNGCAP dao = new NHACUNGCAP();

                    dao.TEN_NCC = x.TEN_NCC;
                    dao.IS_DELETE = false;
                    dao.MODIFILEDDATE = DateTime.Now.Date;
                    dao.MODIFILEDBY = user;
                    dao.EMAIL_NCC = x.EMAIL_NCC;
                    dao.DIACHI_NCC = x.DIACHI_NCC;
                    dao.MANCC = x.MANCC;
                    dao.SDT_NCC = x.SDT_NCC;


                    dao.CREATEDATE = DateTime.Now.Date;
                    dao.CREATEBY = user;

                    db.NHACUNGCAPs.Add(dao);
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