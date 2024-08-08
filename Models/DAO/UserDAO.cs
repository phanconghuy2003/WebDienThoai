using bandienthoai.Models.EF;
using Commom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bandienthoai.Models.DAO
{
    public class UserDAO
    {
        QlBanHangDbContext db = null;
        public UserDAO()
        {
            db = new QlBanHangDbContext();
        }
        public decimal Insert(TAIKHOAN tk)
        {
            db.TAIKHOANs.Add(tk);
            db.SaveChanges();
            return tk.ID;

        }
        public bool CheckUserName(string username)
        {
            return db.TAIKHOANs.Count(x => x.TENTAIKHOAN == username) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.TAIKHOANs.Count(x => x.EMAIL_TK == email) > 0;
        }
        public TAIKHOAN GetByUserName(string userName)
        {
            return db.TAIKHOANs.SingleOrDefault(x => x.TENTAIKHOAN == userName);
        }
        //login
        public decimal Login(string user, string pass,bool isshipper=false)
        {
            var result = db.TAIKHOANs.SingleOrDefault(x => x.TENTAIKHOAN == user);
            if (result == null)
            {
                return 0;
            }

            else
            {
                if (isshipper == true)
                {
                    if (result.USERGROUPID == ComonConstants.SHIP_GROUP)
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
                        return -3;
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
    }
}