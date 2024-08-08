using bandienthoai.Areas.Admin.Models.EF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bandienthoai.Areas.Admin.Models.DAO
{
    public class LoaiTaiKhoanDAO
    {
        QlBanHangDbContext db = null;
        public LoaiTaiKhoanDAO()
        {
            db = new QlBanHangDbContext();
        }
        public List<LoaitaiKhoanModel> GetListLoaiTK()
        {
            var dao = db.LOAITAIKHOANs.Where(x => x.IS_DELETE == false).Select(x => new LoaitaiKhoanModel
            {
                IDLOAITAIKHOAN = x.ID,
                TENLOAITAIKHOAN = x.TENLOAITK,
                IS_DELETE = x.IS_DELETE,
                CREATEDATE = x.CREATEDATE,
                MODIFILEDDATE=x.MODIFILEDDATE,
                MODIFILEDBY = x.MODIFILEDBY,
                CREATEBY = x.CREATEBY,
                GHICHU = x.GHICHU_LOAITAIKHOAN
            }).ToList();
            return dao;
        }
        public string GetListLoaiTaikhoanByID(string ID)
        {
            var model = db.LOAITAIKHOANs.Where(x => x.ID == ID).SingleOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return value;
        }
        public bool Delete(string id)
        {
            try
            {
                if (Commom.ComonConstants.MOD_GROUP == id || Commom.ComonConstants.ADMIN_GROUP == id)
                {
                    return false;
                }
                var t = db.LOAITAIKHOANs.Find(id);
                t.IS_DELETE = true;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        //public LOAITAIKHOAN GetTypeUserByID(int ID)
        //{

        //        return db.LOAITAIKHOANs.Where(x => x.LOAITAIKHOAN_ID == ID).SingleOrDefault();



        //}
        public int SaveData(LoaitaiKhoanModel x, string user)
        {
            try
            {
                var typeUser = db.LOAITAIKHOANs.Find(x.IDLOAITAIKHOAN);
                if (typeUser != null)
                {


                    LOAITAIKHOAN dao = db.LOAITAIKHOANs.SingleOrDefault(m => m.IS_DELETE == false && m.ID == x.IDLOAITAIKHOAN);

                    dao.ID = x.IDLOAITAIKHOAN;
                    dao.TENLOAITK = x.TENLOAITAIKHOAN;
                    dao.IS_DELETE = false;
                    dao.MODIFILEDDATE = DateTime.Now.Date;
                    dao.MODIFILEDBY = user;

                    dao.GHICHU_LOAITAIKHOAN = x.GHICHU;
                    db.SaveChanges();

                    return 1;

                }
                else
                {

                    LOAITAIKHOAN dao = new LOAITAIKHOAN();
                    dao.IS_DELETE = false;
                    dao.ID = x.IDLOAITAIKHOAN;
                    dao.TENLOAITK = x.TENLOAITAIKHOAN;


                    dao.CREATEDATE = DateTime.Now.Date;
                    dao.CREATEBY = user;
                    dao.GHICHU_LOAITAIKHOAN = x.GHICHU;
                    db.LOAITAIKHOANs.Add(dao);
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