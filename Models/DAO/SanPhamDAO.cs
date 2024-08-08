
using bandienthoai.Models.EF;
using bandienthoai.Models.DAO.Comparers;
using bandienthoai.Models.DAO.Objects;
using bandienthoai.Models.DAO.Parsers;
using bandienthoai.Models.DAO.Recommenders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using System.IO;

namespace bandienthoai.Models.DAO
{
    public class SanPhamDAO
    {
        QlBanHangDbContext db = null;
        public SanPhamDAO()
        {
            db = new QlBanHangDbContext();
        }
        public List<SANPHAM> GetListAllProduct( ref int TotalRecord, int page = 1, int PageSize = 2)
        {
            TotalRecord = db.SANPHAMs.Count();
            var kq = db.SANPHAMs.OrderByDescending(x => x.CREATEDATE).Skip((PageSize - 1) * page).Take(PageSize).ToList();

            return kq;
        }

        internal object OrderByDescending(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        public List<SANPHAM> GetListAllKhuyenMai(ref int TotalRecord, int page = 1, int PageSize = 2)
        {
            TotalRecord = db.SANPHAMs.Where(t=>t.KHUYENMAI>0).Count();
            var kq = db.SANPHAMs.Where(t => t.KHUYENMAI > 0).OrderByDescending(x => x.CREATEDATE).Skip((PageSize - 1) * page).Take(PageSize).ToList();

            return kq;
        }
        //san phảm mới
        public List<SANPHAM> GetListNewProduct(int top)
        {
            var kq = db.SANPHAMs.OrderByDescending(x=>x.CREATEDATE).Take(top).ToList();

            return kq;
        }
        public SANPHAM getProduct(long id)
        {
            return db.SANPHAMs.Find(id);
        }
        public void update(long id)
        {
            var dao= db.SANPHAMs.Find(id);
            dao.LUOTXEM += 1;
            db.SaveChanges();
        }
        //recommend function
        public List<SANPHAM> Recommender(long id, int currentid)
        {
            //if user already had data in rating table in db then use Tu's recommend method
            try
            {
                List<SANPHAM> list = new List<SANPHAM>();
                //init recommender for get 50 user nearest
                UserCollaborativeFilterRecommender recommender = new UserCollaborativeFilterRecommender( 50);
                //init parser for get data from db  
                UserBehaviorDatabaseParser parser = new UserBehaviorDatabaseParser();
                //load data to holder
                UserBehaviorDatabase db1 = parser.LoadUserBehaviorDatabase();
                //tranform to matrix
                recommender.Train(db1);
                //get list 5 itemIDs recommend as output
                List<Suggestion> result = recommender.GetSuggestions(currentid, 5);
                //get data for items from it's ID
                foreach (Suggestion suggestion in result)
                {
                    SANPHAM t = db.SANPHAMs.FirstOrDefault(sp => sp.SANPHAM_ID == suggestion.ArticleID);
                    if (t.SANPHAM_ID != id)
                    {
                        list.Add(t);
                    }

                }

                var kq = list;

                return kq;
            }
            //else use Quoc's recommend method
            catch (Exception e)
            {
                List<SANPHAM> list = new List<SANPHAM>();
                var ListRecom = db.RECOMMENDERs.Where(x => x.IDPRODUCT1 == id || x.IDPRODUCT2 == id).OrderByDescending(y => y.QUANLITY).ToList();
                for (int i = 0; i < ListRecom.Count; i++)
                {
                    var sp = new SANPHAM();
                    if (ListRecom[i].IDPRODUCT1 == id)
                    {
                        sp = getProduct(ListRecom[i].IDPRODUCT2);
                    }
                    else
                    {
                        sp = getProduct(ListRecom[i].IDPRODUCT1);
                    }
                    list.Add(sp);
                }
                var kq = list.OrderByDescending(t => t.CREATEDATE).Take(20).ToList();

                return kq;
            }
        }
        //get list image
        public List<IMAGEPRODDUCT> GetListImagetId(decimal id)
        {
            try
            {
                return db.IMAGEPRODDUCTs.Where(x => x.IDPRODUCT == id).ToList();
         }
            catch
            {
                return null;
            }



        }
        //public List<SANPHAM> GetListFeatureProduct()
        //{
        //    var kq = db.SANPHAMs.Where(x => x.TOP).Take(top).ToList();

        //    return kq;
        //}
        //get sp mới

        //public List<ProductViewModel> GetListPromotion()
        //{

        //    var kq = (from a in db.SANPHAMs
        //              join b in db.KHUYENMAIs
        //              on a.SANPHAM_ID equals b.IDSANPHAM
        //              where b.GIATRI > 0
        //              select new
        //              {

        //                  ID = a.SANPHAM_ID,
        //                  Images = a.HINHANH_SANPHAM,
        //                  MetaTitle = a.GHICHU_SANPHAM,
        //                  Price = a.GIA_SANPHAM,
        //                  Promotion = b.GIATRI,
        //                  Name = a.TEN_SANPHAM,
        //                  Luotxem = a.LUOTXEM

        //              }).AsEnumerable().Select(x => new ProductViewModel
        //              {

        //                  ID = x.ID,
        //                  Images = x.Images,
        //                  MetaTitle = x.MetaTitle,
        //                  Price = x.Price,
        //                  Promotion = x.Promotion,
        //                  Name = x.Name,
        //                  Luotxem = x.Luotxem,
        //              });

        //    return kq.ToList();
        //}
        public List<SANPHAM> GetListKhuyenMai()
        {
            var kq = db.SANPHAMs.Where(t => t.KHUYENMAI > 0).ToList();

            return kq;
        }
        // get list product
        public List<SANPHAM> GetListProductById(long CateId,ref int TotalRecord, int page=1,int PageSize=2)
        {
            TotalRecord = db.SANPHAMs.Where(t => t.LOAISANPHAM_ID == CateId).Count();
            var kq = db.SANPHAMs.Where(t => t.LOAISANPHAM_ID ==CateId).OrderByDescending(x=>x.CREATEDATE).Skip((PageSize-1) * page).Take(PageSize).ToList();

            return kq;
        }
        // get list product new
        public List<SANPHAM> GetListNew(int  tmp)
        {
            var kq = db.SANPHAMs.OrderByDescending(t=>t.CREATEDATE).Take(tmp).ToList();

            return kq;
        }
       
        
        //search
        public List<ProductViewModel> Search(string Keyword, ref int TotalRecord, int page = 1, int PageSize = 2)
        {
            TotalRecord = db.SANPHAMs.Where(t => t.TEN_SANPHAM.Contains(Keyword)).Count();

            var model = (from a in db.SANPHAMs
                         join b in db.LOAISANPHAMs
                         on a.LOAISANPHAM_ID equals b.LOAISANPHAM_ID
                         where a.TEN_SANPHAM.Contains(Keyword)
                         select new
                         {
                             CateMetatitle = b.GHICHU_LOAISANPHAM,
                             CateName = b.TEN_LOAISANPHAM,
                             ID = a.SANPHAM_ID,
                             Images = a.HINHANH_SANPHAM,
                             MetaTitle = a.GHICHU_SANPHAM,
                             Price = a.GIA_SANPHAM,
                             DateKT=a.NGAYKTKM,
                             Promotion = a.KHUYENMAI,
                             Name = a.TEN_SANPHAM,
                             Luotxem = a.LUOTXEM

                         }).AsEnumerable().Select(x => new ProductViewModel
                         {
                             CateMetatitle = x.CateMetatitle,
                             CateName = x.CateName,
                             ID = x.ID,
                             NgayKTKM=x.DateKT,
                             Images = x.Images,
                             MetaTitle = x.MetaTitle,
                             Price = x.Price,
                             Promotion = x.Promotion,
                             Name = x.Name,
                             Luotxem = x.Luotxem,
                         });
           var kq= model.OrderByDescending(x => x.CREATEDATE).Skip((PageSize - 1) * page).Take(PageSize).ToList();
            return kq.ToList();
        }
        public List<SANPHAM> GetListRelatedProducts(long id)
        {
            var product = db.SANPHAMs.Find(id);
            var kq = db.SANPHAMs.Where(t => t.SANPHAM_ID !=id && t.LOAISANPHAM_ID==product.LOAISANPHAM_ID).ToList();

            return kq;
        }
        public List<string> ListName(string key)
        {
          
            var kq = db.SANPHAMs.Where(t => t.TEN_SANPHAM.Contains(key)).Select(x=>x.TEN_SANPHAM).ToList();

            return kq;
        }
        public SANPHAM ViewDetail(long id)
        {
        return db.SANPHAMs.Find(id);

           
        }

        public bool insertStar(Rating rating)
        {

            db.Ratings.Add(rating);
            db.SaveChanges();
            return true;


        }

    }
}