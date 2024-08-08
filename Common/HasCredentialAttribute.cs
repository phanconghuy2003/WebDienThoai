using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Commom;
namespace bandienthoai
{
    public class HasCredentialAttribute:AuthorizeAttribute
    {
        public string RoleID { set; get; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //var isAuthorize = base.AuthorizeCore(httpContext);
            //if (!isAuthorize)
            //{
            //    return false;
            //}
            var session = (UserLogin)HttpContext.Current.Session[Common.CommonStants.USER_SESSION];
            if (session==null)
            {
                return false;
            }
            List< string> privil = this.GetCredentialByLoggedInUser(session.userName);
            if (privil.Contains(this.RoleID) || (session.GroupID == ComonConstants.ADMIN_GROUP))
            {
                return true;
            }
            else
            {
                return false;
            }

      }
     
        private List<string> GetCredentialByLoggedInUser(string UserName)
        {
            var credentia= (List<string>)HttpContext.Current.Session[Common.CommonStants.SESSION_CREDENTIAL];
            return credentia;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult
            {
                ViewName = "/Areas/Admin/Views/Shared/TrangLoi.cshtml"
            };
        }
    }
}