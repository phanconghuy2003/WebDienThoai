using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using bandienthoai.Areas.Admin.Models.EF;
using bandienthoai.Common;
using Commom;

namespace bandienthoai.Areas.Admin.Models.DAO
{
  
    public class UserDAO
    {
       QlBanHangDbContext db=null;
       public UserDAO()
        {
            db = new QlBanHangDbContext();
        }
        public bool CheckUserName(string username)
        {
            return db.TAIKHOANs.Count(x => x.TENTAIKHOAN == username) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.TAIKHOANs.Count(x => x.EMAIL_TK == email) > 0;
        }
        public decimal Insert(TAIKHOAN tk)
        {
            db.TAIKHOANs.Add(tk);
            db.SaveChanges();
            return tk.ID;
            
        }
        public List<LOAITAIKHOAN> getAllTypeUser()
        {
            return db.LOAITAIKHOANs.Where(t=>t.IS_DELETE==false).ToList();
        }
        public List<LOAITAIKHOAN> getmod()
        {
            return db.LOAITAIKHOANs.Where(t => t.IS_DELETE == false && t.ID=="MOD").ToList();
        }
        public bool Update(TAIKHOAN tk)
        {
            try
            {
                var user = db.TAIKHOANs.Find(tk.ID);
                user.HOTEN = tk.HOTEN;
                user.MATKHAU = tk.MATKHAU;
                user.SDT = tk.SDT;
                user.STATUS = tk.STATUS;
               
                user.PROVINCEID = tk.PROVINCEID;
                user.DISTRICTID = tk.DISTRICTID;
                user.GHICHU_TK = tk.GHICHU_TK;
                user.MODIFILEDBY = tk.MODIFILEDBY;
                user.MODIFILEDDATE = DateTime.Now;

                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        //inser quyền
        public CREDENTIAL GetCredentialByGroupID(string GroupID,string RoleID)
        {
            return db.CREDENTIALs.Find(GroupID, RoleID);
        }
        public void DeleteCredential()
        {
            db.CREDENTIALs.RemoveRange(db.CREDENTIALs);
            db.SaveChanges();
        }
        public bool InsertRole(string id,List<string> list)
        {
            DeleteCredential();
            bool kq = false;
            foreach (var item in list)
            {
                //var model = GetCredentialByGroupID(id,item);
                //if (model==null){
                    var credential = new CREDENTIAL();
                    credential.USERGROUPID = id;
                    credential.ROLEID = item;
                    db.CREDENTIALs.Add(credential);
                    db.SaveChanges();
                    kq = true;
                //}
            }
            return kq;
        }
        //get all quyeenf
        public List<ROLE> GetListAllRole()
        {
            return db.ROLEs.Where(x=>x.ID != "PHAN_QUYEN").ToList();
        }
        public List<CREDENTIAL> GetRoleById(string id)
        {
            return db.CREDENTIALs.Where(x => x.USERGROUPID == id).ToList();
        }
        //get list quyền
        public List<RoleViewModel> GetListRole(string id="")
        {
            var list = (from a in db.LOAITAIKHOANs
                        join b in db.CREDENTIALs
                        on a.ID equals b.USERGROUPID
                        join c in db.ROLEs
                        on b.ROLEID equals c.ID
                      where c.ID!= "PHAN_QUYEN"
                        select new
                        {

                            GroupID = a.ID,
                            RoleID = c.ID,
                            GroupName = a.TENLOAITK,
                            RoleName = c.NAME
                        }).AsEnumerable().Select(x => new RoleViewModel()
                        {
                            GroupID = x.GroupID,
                            RoleID = x.RoleID,
                            NameGroup = x.GroupName,
                            NameRole = x.RoleName
                        });
            if(id!="")
            {
                return list.Where(x=>x.GroupID==id).ToList();
            }
            return list.ToList();
        }
        public List<string> GetCredential(string username)
        {
            var user = db.TAIKHOANs.Single(x => x.TENTAIKHOAN == username);
            var data = (from a in db.CREDENTIALs
                       join b in db.LOAITAIKHOANs
                       on a.USERGROUPID equals b.ID
                       join c in db.ROLEs
                       on a.ROLEID equals c.ID
                       where b.ID==user.USERGROUPID
                       select new 
                       {
                           userId = a.ROLEID,
                           GroupID = a.USERGROUPID
                       }).AsEnumerable().Select(x=>new CREDENTIAL()
                       {
                           ROLEID = x.userId,
                           USERGROUPID = x.GroupID
                       })
                       ;
            return data.Select(x=>x.ROLEID).ToList();
        }
        public decimal Login(string user, string pass,bool IsLoginAdmin=false)
        {
            var result = db.TAIKHOANs.SingleOrDefault(x => x.TENTAIKHOAN == user);
            if (result == null)
            {
                return 0;
            }
            
            else
            {
                if(IsLoginAdmin==true)
                {
                    if (result.USERGROUPID == ComonConstants.ADMIN_GROUP || result.USERGROUPID == ComonConstants.MOD_GROUP)
                    {

                        if (result.STATUS == false)
                        {
                            return -1;
                        }
                        else
                        {
                            if (result.MATKHAU == pass)
                            {
                                return 1;
                            }
                            return -2;
                        }
                    }
                    else
                    {
                        return -3;
                    }
                }
                else
                {
                    if (result.STATUS == false)
                    {
                        return -1;
                    }
                    else
                    {
                        if (result.MATKHAU == pass)
                        {
                            return 1;
                        }
                        return -2;
                    }
                }
                   
            }
        }
       
        public bool Delete(decimal id)
        {
            try
            {
                var user = db.TAIKHOANs.Find(id);
                db.TAIKHOANs.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
          
        }
        
            public TAIKHOAN GetByUserName(string userName)
        {
            return db.TAIKHOANs.SingleOrDefault(x => x.TENTAIKHOAN == userName);
        }
        public TAIKHOAN GetByID(int userName)
        {
            return db.TAIKHOANs.SingleOrDefault(x => x.ID == userName);
        }
        public UserViewModel ViewDetail(decimal id)
        {
            var model= db.TAIKHOANs.Find(id);
            var user = new UserViewModel();
            user.ID = model.ID;
            user.Name = model.HOTEN;
            user.IDTypeUser = model.USERGROUPID;
        
            user.UserName = model.TENTAIKHOAN;
           
            user.Phone = model.SDT;
    
            user.Email = model.EMAIL_TK;
            return user;
        }

        public bool ChangeStatus(decimal id)
        {
            var user = db.TAIKHOANs.Find(id);
            user.STATUS = !user.STATUS;
            db.SaveChanges();
            return user.STATUS;
        }
        public string GetLoaiTaiKhoanByID(long id)
        {
            var type = db.LOAITAIKHOANs.Find(id);
            return type.TENLOAITK;
        }
        public List<TaiKhoanModel> GetLoaiTaiKhoan()
        {
            
            var res = (from t in db.TAIKHOANs
                      join l in db.LOAITAIKHOANs
                           on t.USERGROUPID equals l.ID into g
                      from d in g.DefaultIfEmpty()
                      select new
                      {
                          id = t.ID,
                          tentk=t.TENTAIKHOAN,
                          LoaiTk = d.TENLOAITK,
                          sdt = t.SDT,
                          Email=t.EMAIL_TK,
                          Diachi=t.DIACHI_TK,
                          TrangThai=t.STATUS,
                          hoten=t.HOTEN
                            
                      }).ToList();
            List<TaiKhoanModel> tk = new List<TaiKhoanModel>();
            
            foreach (var item in res)
            {
                TaiKhoanModel m = new TaiKhoanModel();
              m.ID = item.id;
                m.TENTAIKHOAN = item.tentk;
              m.LOAITAIKHOAN = item.LoaiTk;
              m.HOTEN = item.hoten;
              m.STATUS = item.TrangThai;
              m.DIACHI_TK = item.Diachi;
              m.SDT = item.sdt;
                m.EMAIL_TK = item.Email;
                tk.Add(m);
            }
            return tk;
        }
    }
   
}