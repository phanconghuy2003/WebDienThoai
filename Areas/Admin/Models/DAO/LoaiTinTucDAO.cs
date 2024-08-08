using bandienthoai.Areas.Admin.Models.EF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bandienthoai.Areas.Admin.Models.DAO
{
    public class LoaiTinTucDAO
    {
        QlBanHangDbContext db = null;
        public LoaiTinTucDAO()
        {
            db = new QlBanHangDbContext();
        }
        // lấy tên loại tin tứ từ id tin tức
        public LOAITINTUC GetTypeNewsByID(long ID)
        {
            return db.LOAITINTUCs.Where(x => x.IDLOAITINTUC == ID).SingleOrDefault();
        }
        //get list
        public List<LoaiTinTucModel> GetListTypeNews()
        {
            var dao = db.LOAITINTUCs.Where(x => x.IS_DELETE == false).Select(x => new LoaiTinTucModel
            {
                IDLOAITINTUC = x.IDLOAITINTUC,
                TENLOAITIN = x.TENLOAITIN,
                IS_DELETE = x.IS_DELETE,
                CREATEDATE = x.CREATEDATE,
                MODIFILEDDATE = x.MODIFILEDDATE,
                MODIFILEDBY = x.MODIFILEDBY,
                CREATEBY = x.CREATEBY

            }).ToList();
            // var dao = db.LOAITINTUCs.ToList();
            return dao;
        }
        // delete
        public bool Delete(int id)
        {
            try
            {
                var t = db.LOAITINTUCs.Find(id);
                db.LOAITINTUCs.Remove(t);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        //save data
        public int SaveData(LoaiTinTucModel x, string user)
        {
            try
            {
                if (x.IDLOAITINTUC > 0)
                {


                    LOAITINTUC dao = db.LOAITINTUCs.SingleOrDefault(m => m.IS_DELETE == false && m.IDLOAITINTUC == x.IDLOAITINTUC);


                    dao.TENLOAITIN = x.TENLOAITIN;
                    dao.IS_DELETE = false;
                    dao.MODIFILEDDATE = DateTime.Now.Date;
                    dao.MODIFILEDBY = user;
                    db.SaveChanges();

                    return 1;

                }
                else
                {

                    LOAITINTUC dao = new LOAITINTUC();
                    dao.IS_DELETE = false;

                    dao.TENLOAITIN = x.TENLOAITIN;


                    dao.CREATEDATE = DateTime.Now.Date;
                    dao.CREATEBY = user;

                    db.LOAITINTUCs.Add(dao);
                    db.SaveChanges();

                    return 2;
                }

            }
            catch
            {
                return 0;
            }

        }

        public string GetListTypeNewsByID(long ID)
        {
            var model = db.LOAITINTUCs.Where(x => x.IDLOAITINTUC == ID).SingleOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return value;
        }
    }
}